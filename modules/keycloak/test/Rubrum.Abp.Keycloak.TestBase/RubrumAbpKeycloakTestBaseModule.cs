using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(AbpAuthorizationModule))]
[DependsOn(typeof(RubrumAbpKeycloakModule))]
[DependsOn(typeof(RubrumAbpKeycloakDomainModule))]
public class RubrumAbpKeycloakTestBaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var url = Environment.GetEnvironmentVariable("KEYCLOAK_URL") ?? "http://localhost:8080";

        context.Services.AddAlwaysAllowAuthorization();

        Configure<RubrumAbpKeycloakOptions>(options =>
        {
            options.Url = url;
            options.DefaultRealmName = "master";
            options.AdminUserName = "admin";
            options.AdminPassword = "12345";
        });

        Configure<RubrumAbpKeycloakClientsOptions>(options =>
        {
            options.Apps = new Dictionary<string, KeycloakClientOptions>
            {
                {
                    "swagger-test",
                    new KeycloakClientOptions
                    {
                        ClientId = "swagger-test",
                        Name = "swagger-test",
                        Secret = Guid.NewGuid().ToString(),
                        RootUrl = "http://test.io",
                        Enabled = true,
                        FrontChannelLogout = true,
                        PublicClient = true,
                        Scopes =
                        [
                            "test-microservice-1", "test-microservice-2", "test-microservice-3",
                            "test-microservice-4", "test-microservice-5"
                        ]
                    }
                },
                {
                    "test-app",
                    new KeycloakClientOptions
                    {
                        ClientId = "test-app",
                        Name = "test-app",
                        RootUrl = "http://test-app.io",
                        Secret = Guid.NewGuid().ToString(),
                        Enabled = true,
                        FrontChannelLogout = true,
                        PublicClient = true,
                        Scopes =
                        [
                            "test-microservice-1", "test-microservice-2", "test-microservice-3",
                            "test-microservice-4", "test-microservice-5"
                        ]
                    }
                }
            };

            options.Microservices = new Dictionary<string, KeycloakClientOptions>
            {
                {
                    "test-microservice-1",
                    new KeycloakClientOptions
                    {
                        ClientId = "test-microservice-1",
                        Name = "test-microservice-1",
                        RootUrl = "http://test-microservice-1.io",
                        PublicClient = false,
                        ImplicitFlowEnabled = false,
                        AuthorizationServicesEnabled = false,
                        StandardFlowEnabled = false,
                        DirectAccessGrantsEnabled = false,
                        ServiceAccountsEnabled = true,
                        Secret = Guid.NewGuid().ToString(),
                        Attributes = new Dictionary<string, string>
                        {
                            { "oauth2.device.authorization.grant.enabled", "false" },
                            { "oidc.ciba.grant.enabled", "false" }
                        },
                        Scopes = ["test-microservice-4"]
                    }
                },
                {
                    "test-microservice-2",
                    new KeycloakClientOptions
                    {
                        ClientId = "test-microservice-2",
                        Name = "test-microservice-2",
                        RootUrl = "http://test-microservice-2.io",
                        PublicClient = false,
                        ImplicitFlowEnabled = false,
                        AuthorizationServicesEnabled = false,
                        StandardFlowEnabled = false,
                        DirectAccessGrantsEnabled = false,
                        ServiceAccountsEnabled = true,
                        Secret = Guid.NewGuid().ToString(),
                        Attributes = new Dictionary<string, string>
                        {
                            { "oauth2.device.authorization.grant.enabled", "false" },
                            { "oidc.ciba.grant.enabled", "false" }
                        },
                        Scopes = Array.Empty<string>()
                    }
                },
                {
                    "test-microservice-3",
                    new KeycloakClientOptions
                    {
                        ClientId = "test-microservice-3",
                        Name = "test-microservice-3",
                        RootUrl = "http://test-microservice-3.io",
                        PublicClient = false,
                        ImplicitFlowEnabled = false,
                        AuthorizationServicesEnabled = false,
                        StandardFlowEnabled = false,
                        DirectAccessGrantsEnabled = false,
                        ServiceAccountsEnabled = true,
                        Secret = Guid.NewGuid().ToString(),
                        Attributes = new Dictionary<string, string>
                        {
                            { "oauth2.device.authorization.grant.enabled", "false" },
                            { "oidc.ciba.grant.enabled", "false" }
                        },
                        Scopes = Array.Empty<string>()
                    }
                },
                {
                    "test-microservice-4",
                    new KeycloakClientOptions
                    {
                        ClientId = "test-microservice-4",
                        Name = "test-microservice-4",
                        RootUrl = "http://test-microservice-4.io",
                        PublicClient = false,
                        ImplicitFlowEnabled = false,
                        AuthorizationServicesEnabled = false,
                        StandardFlowEnabled = false,
                        DirectAccessGrantsEnabled = false,
                        ServiceAccountsEnabled = true,
                        Secret = Guid.NewGuid().ToString(),
                        Attributes = new Dictionary<string, string>
                        {
                            { "oauth2.device.authorization.grant.enabled", "false" },
                            { "oidc.ciba.grant.enabled", "false" }
                        },
                        Scopes = Array.Empty<string>()
                    }
                },
                {
                    "test-microservice-5",
                    new KeycloakClientOptions
                    {
                        ClientId = "test-microservice-5",
                        Name = "test-microservice-5",
                        RootUrl = "http://test-microservice-5.io",
                        PublicClient = false,
                        ImplicitFlowEnabled = false,
                        AuthorizationServicesEnabled = false,
                        StandardFlowEnabled = false,
                        DirectAccessGrantsEnabled = false,
                        ServiceAccountsEnabled = true,
                        Secret = Guid.NewGuid().ToString(),
                        Attributes = new Dictionary<string, string>
                        {
                            { "oauth2.device.authorization.grant.enabled", "false" },
                            { "oidc.ciba.grant.enabled", "false" }
                        },
                        Scopes = Array.Empty<string>()
                    }
                }
            };
        });
    }
}
