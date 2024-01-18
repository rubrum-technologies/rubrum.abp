using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(RubrumAbpLanguageManagementEntityFrameworkCoreTestModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementApplicationModule))]
public class RubrumAbpLanguageManagementApplicationTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAlwaysAllowAuthorization();
    }
}
