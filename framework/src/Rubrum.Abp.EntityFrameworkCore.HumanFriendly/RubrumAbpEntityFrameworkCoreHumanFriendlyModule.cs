using Rubrum.Abp.HumanFriendly;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.EntityFrameworkCore.HumanFriendly;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(RubrumAbpDddDomainSharedHumanFriendlyModule))]
public class RubrumAbpEntityFrameworkCoreHumanFriendlyModule : AbpModule;
