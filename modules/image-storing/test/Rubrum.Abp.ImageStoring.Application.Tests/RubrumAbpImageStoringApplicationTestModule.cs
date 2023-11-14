using Rubrum.Abp.ImageStoring.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(RubrumAbpImageStoringEntityFrameworkCoreTestModule))]
[DependsOn(typeof(RubrumAbpImageStoringApplicationModule))]
public class RubrumAbpImageStoringApplicationTestModule : AbpModule
{
}
