using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Keycloak;

public class KeycloakDataSeeder(
    IKeycloakClient keycloakClient,
    IConfiguration configuration,
    IOptions<RubrumAbpKeycloakClientsOptions> clientsOptions,
    ILogger<KeycloakDataSeeder> logger)
    : IKeycloakDataSeeder, ITransientDependency
{
    private readonly RubrumAbpKeycloakClientsOptions _clientsOptions = clientsOptions.Value;

    protected IReadOnlyList<GatewayOptions> Gateways =>
        (_clientsOptions.Gateways?.Values ?? []).ToList().AsReadOnly();

    protected IReadOnlyList<KeycloakClientOptions> Microservices =>
        (_clientsOptions.Microservices?.Values ?? []).ToList().AsReadOnly();

    protected IReadOnlyList<KeycloakClientOptions> Apps =>
        (_clientsOptions.Apps?.Values ?? []).ToList().AsReadOnly();

    public virtual async Task SeedAsync()
    {
        await UpdateRealmSettingsAsync();
        await UpdateAdminUserAsync();
        await CreateRoleMapperAsync();
        await CreateClientScopesAsync();
        await CreateClientsAsync();
        await CreateSwaggerClientAsync();
    }

    protected virtual async Task UpdateRealmSettingsAsync()
    {
        var realm = await keycloakClient.GetRealmAsync();
        if (realm.AccessTokenLifespan != 30 * 60)
        {
            realm.AccessTokenLifespan = 30 * 60;
            await keycloakClient.UpdateRealmAsync(realm);
        }
    }

    protected virtual async Task UpdateAdminUserAsync()
    {
        var users = await keycloakClient.GetUsersAsync(username: "admin");
        var adminUser = users.FirstOrDefault();
        if (adminUser == null)
        {
            throw new AdminUserNotProvidedException();
        }

        if (string.IsNullOrEmpty(adminUser.Email))
        {
            adminUser.Email = configuration["Keycloak:AdminEmail"] ?? "admin@admin.ru";
            adminUser.FirstName = "admin";
            adminUser.EmailVerified = true;

            logger.LogInformation("Updating admin user with email and first name...");
            await keycloakClient.UpdateUserAsync(adminUser.Id!, adminUser);
        }
    }

    protected virtual async Task CreateRoleMapperAsync()
    {
        var roleScope = (await keycloakClient.GetClientScopesAsync())
            .FirstOrDefault(q => q.Name == "roles");

        if (roleScope == null)
        {
            return;
        }

        if (roleScope.ProtocolMappers?.TrueForAll(q => q.Name != "roles") == true)
        {
            await keycloakClient.CreateClientScopeProtocolMapperAsync(
                roleScope.Id!,
                new ProtocolMapperRepresentation
                {
                    Name = "roles",
                    Protocol = "openid-connect",
                    ProtocolMapper = "oidc-usermodel-realm-role-mapper",
                    Config = new Dictionary<string, string>
                    {
                        { "access.token.claim", "true" },
                        { "id.token.claim", "true" },
                        { "claim.name", "role" },
                        { "multivalued", "true" },
                        { "userinfo.token.claim", "true" }
                    }
                });
        }
    }

    private async Task CreateClientScopesAsync()
    {
        foreach (var microservice in Microservices)
        {
            await CreateScopeAsync(microservice);
        }
    }

    private async Task CreateScopeAsync(KeycloakClientOptions clientOptions)
    {
        var scopeName = clientOptions.Id;
        var scope = (await keycloakClient.GetClientScopesAsync())
            .FirstOrDefault(q => q.Name == scopeName);

        if (scope == null)
        {
            scope = new ClientScopeRepresentation
            {
                Name = scopeName,
                Description = scopeName + " scope",
                Protocol = "openid-connect",
                Attributes =
                    new Dictionary<string, string>
                    {
                        { "consent.screen.text", scopeName },
                        { "display.on.consent.screen", "true" },
                        { "include.in.token.scope", "true" }
                    },
                ProtocolMappers = new List<ProtocolMapperRepresentation>
                {
                    new()
                    {
                        Name = scopeName,
                        Protocol = "openid-connect",
                        ProtocolMapper = "oidc-audience-mapper",
                        Config = new Dictionary<string, string>
                        {
                            { "id.token.claim", "false" },
                            { "access.token.claim", "true" },
                            { "included.custom.audience", scopeName }
                        }
                    }
                }
            };

            await keycloakClient.CreateClientScopeAsync(scope);
        }
    }

    private async Task CreateClientsAsync()
    {
        foreach (var microservice in Microservices)
        {
            await CreateMicroserviceClientAsync(microservice);
        }

        foreach (var app in Apps)
        {
            await CreateAppClientAsync(app);
        }
    }

    private async Task CreateMicroserviceClientAsync(KeycloakClientOptions microservice)
    {
        var clientId = microservice.Id;
        var client = (await keycloakClient.GetClientsAsync(clientId)).FirstOrDefault();

        if (client == null)
        {
            client = new ClientRepresentation
            {
                ClientId = clientId,
                Name = microservice.Name,
                Protocol = "openid-connect",
                PublicClient = false,
                ImplicitFlowEnabled = false,
                AuthorizationServicesEnabled = false,
                StandardFlowEnabled = false,
                DirectAccessGrantsEnabled = false,
                ServiceAccountsEnabled = true,
                Secret = microservice.Secret,
                Attributes = new Dictionary<string, string>
                {
                    { "oauth2.device.authorization.grant.enabled", "false" },
                    { "oidc.ciba.grant.enabled", "false" }
                }
            };

            await keycloakClient.CreateClientAsync(client);

            await AddOptionalClientScopesAsync(microservice);

            var insertedClient = (await keycloakClient.GetClientsAsync(clientId)).First();

            var clientIdProtocolMapper = insertedClient.ProtocolMappers!.First(q => q.Name == "Client ID");
            clientIdProtocolMapper.Config!["claim.name"] = "client_id";

            await keycloakClient.UpdateClientAsync(insertedClient.Id!, insertedClient);
        }
    }

    private async Task CreateAppClientAsync(KeycloakClientOptions app)
    {
        var clientId = app.Id;
        var client = (await keycloakClient.GetClientsAsync(clientId)).FirstOrDefault();

        if (client == null)
        {
            client = new ClientRepresentation
            {
                ClientId = clientId,
                Name = app.Name,
                Protocol = "openid-connect",
                Enabled = true,
                BaseUrl = app.RootUrl,
                RedirectUris = [$"{app.RootUrl.TrimEnd('/')}/signin-oidc"],
                Secret = app.Secret,
                FrontChannelLogout = true,
                PublicClient = true,
                ImplicitFlowEnabled = true,
                Attributes = new Dictionary<string, string>
                {
                    { "post.logout.redirect.uris", $"{app.RootUrl.TrimEnd('/')}/signout-callback-oidc" }
                }
            };

            await keycloakClient.CreateClientAsync(client);

            await AddOptionalClientScopesAsync(app);
        }
    }

    private async Task CreateSwaggerClientAsync()
    {
        var swagger = _clientsOptions.Swagger;

        if (swagger is null)
        {
            return;
        }

        var client = (await keycloakClient.GetClientsAsync(swagger.Id))
            .FirstOrDefault();

        if (client == null)
        {
            client = new ClientRepresentation
            {
                ClientId = swagger.Id,
                Name = swagger.Name,
                Protocol = "openid-connect",
                Enabled = true,
                RedirectUris = Microservices
                    .Select(x => $"{x.RootUrl}/swagger/oauth2-redirect.html")
                    .Union(Gateways.Select(x => $"{x.RootUrl}/swagger/oauth2-redirect.html"))
                    .Union(new[] { swagger.RootUrl })
                    .ToList(),
                Secret = swagger.Secret,
                FrontChannelLogout = true,
                PublicClient = true
            };

            await keycloakClient.CreateClientAsync(client);
            await AddOptionalClientScopesAsync(swagger);
        }
    }

    private async Task AddOptionalClientScopesAsync(KeycloakClientOptions clientOptions)
    {
        var clientId = clientOptions.Id;
        var scopes = clientOptions.Scopes;

        var client = (await keycloakClient.GetClientsAsync(clientId)).FirstOrDefault();

        if (client == null)
        {
            logger.LogError("Couldn't find {Client}! Could not seed optional scopes!", clientId);
            return;
        }

        var clientOptionalScopes = (await keycloakClient.GetOptionalClientScopesAsync(client.Id!)).ToList();
        var clientScopes = (await keycloakClient.GetClientScopesAsync()).ToList();

        foreach (var scope in scopes.Where(scope => clientOptionalScopes.TrueForAll(q => q.Name != scope)))
        {
            var serviceScope = clientScopes.Find(q => q.Name == scope);

            if (serviceScope is null)
            {
                continue;
            }

            logger.LogInformation("Seeding {Scope} scope to {Client}", scope, clientId);
            await keycloakClient.UpdateOptionalClientScopeAsync(client.Id!, serviceScope.Id!);
        }
    }
}
