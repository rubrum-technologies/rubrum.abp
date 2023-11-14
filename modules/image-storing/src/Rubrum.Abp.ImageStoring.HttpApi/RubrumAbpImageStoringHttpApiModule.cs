using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.ImageStoring.Localization.Rubrum.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(RubrumAbpImageStoringApplicationContractsModule))]
public class RubrumAbpImageStoringHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(RubrumAbpImageStoringHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<RubrumAbpImageStoringResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
