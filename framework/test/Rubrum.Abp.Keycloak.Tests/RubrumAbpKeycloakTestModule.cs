using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(AbpAuthorizationModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(RubrumAbpKeycloakModule))]
public class RubrumAbpKeycloakTestModule : AbpModule
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
    }
}
