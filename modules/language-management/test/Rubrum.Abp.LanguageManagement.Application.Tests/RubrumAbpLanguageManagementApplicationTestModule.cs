using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(RubrumAbpLanguageManagementEntityFrameworkCoreTestModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementApplicationModule))]
public class RubrumAbpLanguageManagementApplicationTestModule : AbpModule
{
    
}
