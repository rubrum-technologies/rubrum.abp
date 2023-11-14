using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(typeof(RubrumAbpImageStoringDomainModule))]
[DependsOn(typeof(RubrumAbpImageStoringApplicationContractsModule))]
public class RubrumAbpImageStoringApplicationModule : AbpModule
{
    
}
