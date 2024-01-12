using Rubrum.Abp.Ddd.HumanFriendly;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.EntityFrameworkCore.HumanFriendly;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(RubrumAbpDddSharedHumanFriendlyModule))]
public class RubrumAbpEntityFrameworkCoreHumanFriendlyModule : AbpModule;
