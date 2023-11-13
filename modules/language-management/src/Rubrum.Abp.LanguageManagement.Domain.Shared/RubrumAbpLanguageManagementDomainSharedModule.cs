using Rubrum.Abp.LanguageManagement.Localization.Rubrum.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(AbpDddDomainSharedModule))]
public class RubrumAbpLanguageManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpLanguageManagementDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<RubrumAbpLanguageManagementResource>("ru")
                .AddVirtualJson("/Localization/Rubrum/Abp/LanguageManagement");

            options.DefaultResourceType = typeof(RubrumAbpLanguageManagementResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Rubrum.Abp.LanguageManagement", typeof(RubrumAbpLanguageManagementResource));
        });
    }
}
