using Rubrum.Abp.Data;
using Rubrum.Abp.ImageStoring.ObjectExtending;
using Rubrum.Abp.Imaging;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(AbpBlobStoringModule))]
[DependsOn(typeof(RubrumAbpDataModule))]
[DependsOn(typeof(RubrumAbpImagingAbstractionsModule))]
[DependsOn(typeof(RubrumAbpImageStoringDomainSharedModule))]
public class RubrumAbpImageStoringDomainModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                ImageStoringModuleExtensionConstants.ModuleName,
                ImageStoringModuleExtensionConstants.EntityNames.ImageInformation,
                typeof(ImageInformation)
            );
        });
    }
}
