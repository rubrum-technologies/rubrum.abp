using Rubrum.Abp.ImageStoring.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(RubrumAbpImageStoringEntityFrameworkCoreTestModule))]
public class RubrumAbpImageStoringDomainTestModule : AbpModule;
