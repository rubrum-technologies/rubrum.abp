using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Ddd.HumanFriendly;

[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(RubrumAbpDddSharedHumanFriendlyModule))]
public class RubrumAbpDddApplicationContractsHumanFriendlyModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddConventionalRegistrar(new HumanFriendlyAppServiceConventionalRegistrar());
    }
}
