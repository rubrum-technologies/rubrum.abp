using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.Graphql.Localization.Rubrum.Abp.Graphql;
using Volo.Abp.FluentValidation;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

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

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpGraphqlFluentValidationModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<RubrumAbpGraphqlFluentValidationResource>("en")
                .AddVirtualJson("/Localization/Rubrum/Abp/Graphql/FluentValidation");

            options.DefaultResourceType = typeof(RubrumAbpGraphqlFluentValidationResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Rubrum.Abp.Graphql", typeof(RubrumAbpGraphqlFluentValidationResource));
        });
    }
}
