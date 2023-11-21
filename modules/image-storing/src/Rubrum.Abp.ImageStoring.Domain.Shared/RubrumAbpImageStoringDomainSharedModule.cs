using Rubrum.Abp.ImageStoring.Localization.Rubrum.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpDddDomainSharedModule))]
public class RubrumAbpImageStoringDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpImageStoringDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<RubrumAbpImageStoringResource>("en")
                .AddVirtualJson("/Localization/Rubrum/Abp/ImageStoring");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Rubrum.Abp.ImageStoring", typeof(RubrumAbpImageStoringResource));
        });
    }
}
