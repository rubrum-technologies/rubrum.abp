using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(RubrumAbpLanguageManagementEntityFrameworkCoreTestModule))]
public class RubrumAbpLanguageManagementDomainTestModule : AbpModule
{
}
