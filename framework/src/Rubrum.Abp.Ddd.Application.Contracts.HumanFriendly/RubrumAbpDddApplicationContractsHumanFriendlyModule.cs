using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.HumanFriendly;

[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(RubrumAbpDddDomainSharedHumanFriendlyModule))]
public class RubrumAbpDddApplicationContractsHumanFriendlyModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddConventionalRegistrar(new HumanFriendlyAppServiceConventionalRegistrar());
    }
}
