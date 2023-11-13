using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.MultilingualObjects;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql.MultilingualObjects;

[DependsOn(typeof(RubrumAbpGraphqlTestBaseModule))]
[DependsOn(typeof(RubrumAbpGraphqlMultilingualObjectsModule))]
public class RubrumAbpGraphqlMultilingualObjectsTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        LanguageDefault.Culture = "ru";

        var graphql = context.Services.GetGraphql();

        graphql
            .AddQueryType(d => d.Name(OperationTypeNames.Query))
            .ModifyRequestOptions(options =>
            {
                options.IncludeExceptionDetails = true;
            });
    }
}
