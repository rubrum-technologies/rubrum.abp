using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(RubrumAbpGraphqlContractsModule))]
[DependsOn(typeof(RubrumAbpImageStoringApplicationContractsModule))]
public class RubrumAbpImageStoringGraphqlContractsModule : AbpModule
{
}
