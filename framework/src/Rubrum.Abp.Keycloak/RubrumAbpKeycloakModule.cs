using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Json.SystemTextJson;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpHttpClientModule))]
[DependsOn(typeof(RubrumAbpKeycloakAbstractionsModule))]
public class RubrumAbpKeycloakModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services.AddSingleton<ICurrentKeycloakRealmAccessor>(AsyncLocalCurrentKeycloakRealmAccessor.Instance);

        Configure<AbpSystemTextJsonSerializerOptions>(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        Configure<RubrumAbpKeycloakOptions>(options => configuration
            .GetSection("Keycloak")
            .Bind(options));
    }
}
