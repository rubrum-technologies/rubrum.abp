using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.LanguageManagement.Localization.Rubrum.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementApplicationContractsModule))]
public class RubrumAbpLanguageManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(RubrumAbpLanguageManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<RubrumAbpLanguageManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
