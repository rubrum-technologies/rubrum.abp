using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(RubrumAbpKeycloakAbstractionsModule))]
[DependsOn(typeof(RubrumAbpKeycloakDomainSharedModule))]
public class RubrumAbpKeycloakDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<RubrumAbpKeycloakClientsOptions>(options => configuration
            .GetSection("Keycloak")
            .GetSection("Clients")
            .Bind(options));
    }
}
