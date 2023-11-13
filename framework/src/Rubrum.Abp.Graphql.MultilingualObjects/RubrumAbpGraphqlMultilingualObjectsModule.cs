using Rubrum.Abp.MultilingualObjects;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql.MultilingualObjects;

[DependsOn(typeof(RubrumAbpGraphqlContractsModule))]
[DependsOn(typeof(RubrumAbpMultilingualObjectsModule))]
public class RubrumAbpGraphqlMultilingualObjectsModule : AbpModule
{
}
