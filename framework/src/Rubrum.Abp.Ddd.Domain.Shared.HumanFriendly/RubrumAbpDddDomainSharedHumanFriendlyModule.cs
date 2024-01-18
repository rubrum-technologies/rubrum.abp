using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.HumanFriendly;

[DependsOn(typeof(AbpDddDomainSharedModule))]
public class RubrumAbpDddDomainSharedHumanFriendlyModule : AbpModule;
