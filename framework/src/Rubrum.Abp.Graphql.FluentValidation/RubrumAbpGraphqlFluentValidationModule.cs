using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.Graphql.Localization.Rubrum.Abp.Graphql;
using Volo.Abp.FluentValidation;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql;

[DependsOn(typeof(AbpFluentValidationModule))]
[DependsOn(typeof(AbpLocalizationModule))]
[DependsOn(typeof(RubrumAbpGraphqlModule))]
public class RubrumAbpGraphqlFluentValidationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var graphql = context.Services.GetGraphql();

        graphql.TryAddTypeInterceptor<FluentValidationTypeInterceptor>();
        
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<RubrumAbpGraphqlFluentValidationsResource>("en")
                .AddVirtualJson("/Localization/Rubrum/Abp/Graphql/FluentValidations");

            options.DefaultResourceType = typeof(RubrumAbpGraphqlFluentValidationsResource);
        });
    }
}