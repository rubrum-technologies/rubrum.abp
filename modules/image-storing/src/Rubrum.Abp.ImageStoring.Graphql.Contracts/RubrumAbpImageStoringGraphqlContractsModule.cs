using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(RubrumAbpImageStoringGraphqlContractsModule))]
[DependsOn(typeof(RubrumAbpImageStoringApplicationContractsModule))]
public class RubrumAbpImageStoringGraphqlContractsModule : AbpModule
{
}
