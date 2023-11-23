using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(RubrumAbpGraphqlModule))]
[DependsOn(typeof(RubrumAbpImageStoringApplicationModule))]
[DependsOn(typeof(RubrumAbpImageStoringGraphqlContractsModule))]
public class RubrumAbpImageStoringGraphqlModule : AbpModule
{
}
