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
            options.Swagger = new SwaggerClientOptions
            {
                Id = "swagger-test",
                Name = "swagger-test",
                Secret = Guid.NewGuid().ToString(),
                RootUrl = "http://test.io",
                Scopes = new[]
                {
                    "test-microservice-1",
                    "test-microservice-2",
                    "test-microservice-3",
                    "test-microservice-4",
                    "test-microservice-5"
                }
            };

            options.Apps = new Dictionary<string, KeycloakClientOptions>
            {
                {
                    "test-app",
                    new KeycloakClientOptions
                    {
                        Name = "test-app",
                        RootUrl = "http://test-app.io",
                        Secret = Guid.NewGuid().ToString(),
                        Scopes = new[]
                        {
                            "test-microservice-1",
                            "test-microservice-2",
                            "test-microservice-3",
                            "test-microservice-4",
                            "test-microservice-5"
                        }
                    }
                }
            };

            options.Gateways = new Dictionary<string, GatewayOptions>
            {
                { "gateway-1", new GatewayOptions { RootUrl = "http://test-gateway-1.io" } },
                { "gateway-2", new GatewayOptions { RootUrl = "http://test-gateway-2.io" } },
                { "gateway-3", new GatewayOptions { RootUrl = "http://test-gateway-3.io" } }
            };

            options.Microservices = new Dictionary<string, KeycloakClientOptions>
            {
                {
                    "test-microservice-1",
                    new KeycloakClientOptions
                    {
                        Name = "test-microservice-1",
                        RootUrl = "http://test-microservice-1.io",
                        Secret = Guid.NewGuid().ToString(),
                        Scopes = new[] { "test-microservice-4" }
                    }
                },
                {
                    "test-microservice-2",
                    new KeycloakClientOptions
                    {
                        Name = "test-microservice-2",
                        RootUrl = "http://test-microservice-2.io",
                        Secret = Guid.NewGuid().ToString(),
                        Scopes = Array.Empty<string>()
                    }
                },
                {
                    "test-microservice-3",
                    new KeycloakClientOptions
                    {
                        Name = "test-microservice-3",
                        RootUrl = "http://test-microservice-3.io",
                        Secret = Guid.NewGuid().ToString(),
                        Scopes = Array.Empty<string>()
                    }
                },
                {
                    "test-microservice-4",
                    new KeycloakClientOptions
                    {
                        Name = "test-microservice-4",
                        RootUrl = "http://test-microservice-4.io",
                        Secret = Guid.NewGuid().ToString(),
                        Scopes = Array.Empty<string>()
                    }
                },
                {
                    "test-microservice-5",
                    new KeycloakClientOptions
                    {
                        Name = "test-microservice-5",
                        RootUrl = "http://test-microservice-5.io",
                        Secret = Guid.NewGuid().ToString(),
                        Scopes = Array.Empty<string>()
                    }
                }
            };
        });
    }
}
