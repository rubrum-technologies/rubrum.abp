using Rubrum.Abp.LanguageManagement.ObjectExtending;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(AbpAuthorizationAbstractionsModule))]
[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementDomainSharedModule))]
public class RubrumAbpLanguageManagementApplicationContractsModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper
                .ApplyEntityConfigurationToApi(
                    LanguageManagementModuleExtensionConstants.ModuleName,
                    LanguageManagementModuleExtensionConstants.EntityNames.Language,
                    getApiTypes: new[] { typeof(LanguageDto) },
                    createApiTypes: new[] { typeof(CreateLanguageInput) },
                    updateApiTypes: new[] { typeof(UpdateLanguageInput) }
                );
        });
    }
}
