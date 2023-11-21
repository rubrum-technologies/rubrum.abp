using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

[DependsOn(typeof(RubrumAbpHostingAspNetCoreModule))]
public class RubrumAbpHostingAspNetCoreGatewayModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var proxy = configuration.GetSection("ReverseProxy");

        context.Services
            .AddReverseProxy()
            .LoadFromConfig(proxy);
    }
}
