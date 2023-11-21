using Rubrum.Abp.ImageStoring.ObjectExtending;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpAuthorizationAbstractionsModule))]
[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(RubrumAbpImageStoringDomainSharedModule))]
public class RubrumAbpImageStoringApplicationContractsModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper
                .ApplyEntityConfigurationToApi(
                    ImageStoringModuleExtensionConstants.ModuleName,
                    ImageStoringModuleExtensionConstants.EntityNames.ImageInformation,
                    new[] { typeof(ImageInformationDto) }
                );
        });
    }
}
