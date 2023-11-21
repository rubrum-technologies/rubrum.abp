using Rubrum.Abp.Data;
using Rubrum.Abp.LanguageManagement.ObjectExtending;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(RubrumAbpDataModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementDomainSharedModule))]
public class RubrumAbpLanguageManagementDomainModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                LanguageManagementModuleExtensionConstants.ModuleName,
                LanguageManagementModuleExtensionConstants.EntityNames.SystemLanguage,
                typeof(SystemLanguage)
            );
        });
    }
}
