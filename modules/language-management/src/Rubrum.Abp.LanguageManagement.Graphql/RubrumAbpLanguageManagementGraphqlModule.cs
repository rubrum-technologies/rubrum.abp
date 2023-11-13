using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(RubrumAbpGraphqlModule))]
[DependsOn(typeof(RubrumAbpGraphqlFluentValidationModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementApplicationModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementGraphqlContractsModule))]
public class RubrumAbpLanguageManagementGraphqlModule : AbpModule
{
}
