using Rubrum.Abp.Keycloak.Localization.Rubrum.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpDddDomainSharedModule))]
public class RubrumAbpKeycloakDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpKeycloakDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<RubrumAbpKeycloakResource>("en")
                .AddVirtualJson("/Localization/Rubrum/Abp/Keycloak");

            options.DefaultResourceType = typeof(RubrumAbpKeycloakResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Rubrum.Abp.Keycloak", typeof(RubrumAbpKeycloakResource));
        });
    }
}
