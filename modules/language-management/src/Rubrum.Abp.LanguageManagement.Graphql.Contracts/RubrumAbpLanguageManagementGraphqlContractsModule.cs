using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(RubrumAbpGraphqlContractsModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementApplicationContractsModule))]
public class RubrumAbpLanguageManagementGraphqlContractsModule : AbpModule
{
}
