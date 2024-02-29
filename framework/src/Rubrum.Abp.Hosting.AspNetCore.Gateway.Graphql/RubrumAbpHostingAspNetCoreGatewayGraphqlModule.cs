using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

[DependsOn(typeof(RubrumAbpHostingAspNetCoreGatewayModule))]
public class RubrumAbpHostingAspNetCoreGatewayGraphqlModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var fusion = context.Services.AddFusionGatewayServer();

        context.Services.AddSingleton(fusion);
    }
}
