using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Keycloak;

public class KeycloakDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IKeycloakClient _keycloakClient;
    private readonly RubrumAbpKeycloakClientsOptions _clientsOptions;
    private readonly ILogger<KeycloakDataSeeder> _logger;

    public KeycloakDataSeeder(
        IKeycloakClient keycloakClient,
        IOptions<RubrumAbpKeycloakClientsOptions> clientsOptions,
        ILogger<KeycloakDataSeeder> logger)
    {
        _keycloakClient = keycloakClient;
        _clientsOptions = clientsOptions.Value;
        _logger = logger;
    }

    protected IReadOnlyDictionary<string, GatewayOptions> Gateways => _clientsOptions.Gateways;

    protected IReadOnlyDictionary<string, KeycloakClientOptions> Microservices => _clientsOptions.Microservices;

    protected SwaggerClientOptions Swagger => _clientsOptions.Swagger;
    protected IReadOnlyDictionary<string, KeycloakClientOptions> Apps => _clientsOptions.Apps;

    public virtual async Task SeedAsync(DataSeedContext context)
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
        var realm = await _keycloakClient.GetRealmAsync();
        if (realm.AccessTokenLifespan != 30 * 60)
        {
            realm.AccessTokenLifespan = 30 * 60;
            await _keycloakClient.UpdateRealmAsync(realm);
        }
    }

    protected virtual async Task UpdateAdminUserAsync()
    {
        var users = await _keycloakClient.GetUsersAsync(username: "admin");
        var adminUser = users.FirstOrDefault();
        if (adminUser == null)
        {
            throw new Exception(
                "Keycloak admin user is not provided, check if KEYCLOAK_ADMIN environment variable is passed properly.");
        }

        if (string.IsNullOrEmpty(adminUser.Email))
        {
            adminUser.Email = "admin@admin.ru";
            adminUser.FirstName = "admin";
            adminUser.EmailVerified = true;

            _logger.LogInformation("Updating admin user with email and first name...");
            await _keycloakClient.UpdateUserAsync(adminUser.Id!, adminUser);
        }
    }

    protected virtual async Task CreateRoleMapperAsync()
    {
        var roleScope = (await _keycloakClient.GetClientScopesAsync())
            .FirstOrDefault(q => q.Name == "roles");

        if (roleScope == null)
            return;

        if (roleScope.ProtocolMappers?.All(q => q.Name != "roles") == true)
        {
            await _keycloakClient.CreateClientScopeProtocolMapperAsync(
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
        foreach (var (clientId, _) in Microservices)
        {
            await CreateScopeAsync(clientId);
        }
    }

    private async Task CreateScopeAsync(string scopeName)
    {
        var scope = (await _keycloakClient.GetClientScopesAsync())
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
                        { "include.in.token.scope", "true" },
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

            await _keycloakClient.CreateClientScopeAsync(scope);
        }
    }

    private async Task CreateClientsAsync()
    {
        foreach (var (clientId, microservice) in Microservices)
        {
            await CreateClientAsync(clientId, microservice);
        }

        foreach (var (clientId, app) in Apps)
        {
            await CreateAppClientAsync(clientId, app);
        }
    }

    private async Task CreateClientAsync(string clientId, KeycloakClientOptions microservice)
    {
        var client = (await _keycloakClient.GetClientsAsync(clientId)).FirstOrDefault();

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

            await _keycloakClient.CreateClientAsync(client);

            await AddOptionalClientScopesAsync(clientId, microservice);

            var insertedClient = (await _keycloakClient.GetClientsAsync(clientId)).First();

            var clientIdProtocolMapper = insertedClient.ProtocolMappers!.First(q => q.Name == "Client ID");
            clientIdProtocolMapper.Config!["claim.name"] = "client_id";

            await _keycloakClient.UpdateClientAsync(insertedClient.Id!, insertedClient);
        }
    }

    private async Task CreateAppClientAsync(string clientId, KeycloakClientOptions app)
    {
        var client = (await _keycloakClient.GetClientsAsync(clientId)).FirstOrDefault();

        if (client == null)
        {
            client = new ClientRepresentation
            {
                ClientId = clientId,
                Name = app.Name,
                Protocol = "openid-connect",
                Enabled = true,
                Secret = app.Secret,
                FrontChannelLogout = true,
                PublicClient = true
            };

            await _keycloakClient.CreateClientAsync(client);

            await AddOptionalClientScopesAsync(clientId, app);
        }
    }

    private async Task CreateSwaggerClientAsync()
    {
        var client = (await _keycloakClient.GetClientsAsync(Swagger.Id))
            .FirstOrDefault();

        if (client == null)
        {
            client = new ClientRepresentation
            {
                ClientId = Swagger.Id,
                Name = Swagger.Name,
                Protocol = "openid-connect",
                Enabled = true,
                RedirectUris = Microservices
                    .Select(x => $"{x.Value.RootUrl}/swagger/oauth2-redirect.html")
                    .Union(Gateways.Select(x => $"{x.Value.RootUrl}/swagger/oauth2-redirect.html"))
                    .Union(new[] { Swagger.RootUrl })
                    .ToList(),
                Secret = Swagger.Secret,
                FrontChannelLogout = true,
                PublicClient = true
            };

            await _keycloakClient.CreateClientAsync(client);
            await AddOptionalClientScopesAsync(Swagger.Id, Swagger);
        }
    }

    private async Task AddOptionalClientScopesAsync(string clientId, KeycloakClientOptions keycloakClient)
    {
        var scopes = keycloakClient.Scopes ?? Array.Empty<string>();

        var client = (await _keycloakClient.GetClientsAsync(clientId)).FirstOrDefault();

        if (client == null)
        {
            _logger.LogError("Couldn't find {Client}! Could not seed optional scopes!", clientId);
            return;
        }

        var clientOptionalScopes = (await _keycloakClient.GetOptionalClientScopesAsync(client.Id!)).ToList();
        var clientScopes = (await _keycloakClient.GetClientScopesAsync()).ToList();

        foreach (var scope in scopes)
        {
            if (clientOptionalScopes.All(q => q.Name != scope))
            {
                var serviceScope = clientScopes.FirstOrDefault(q => q.Name == scope);

                if (serviceScope is null)
                {
                    continue;
                }

                _logger.LogInformation("Seeding {Scope} scope to {Client}", scope, clientId);
                await _keycloakClient.UpdateOptionalClientScopeAsync(client.Id!, serviceScope.Id!);
            }
        }
    }
}
