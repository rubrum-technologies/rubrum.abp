using Rubrum.Abp.HumanFriendly;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql.HumanFriendly;

[DependsOn(typeof(RubrumAbpDddApplicationContractsHumanFriendlyModule))]
[DependsOn(typeof(RubrumAbpGraphqlModule))]
public class RubrumAbpGraphqlHumanFriendlyModule : AbpModule;
