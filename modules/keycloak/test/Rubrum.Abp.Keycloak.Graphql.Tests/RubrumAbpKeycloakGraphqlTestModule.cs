using HotChocolate.Data.Filters;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql;
using Rubrum.Abp.Graphql.Extensions;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(RubrumAbpGraphqlTestBaseModule))]
[DependsOn(typeof(RubrumAbpKeycloakTestBaseModule))]
[DependsOn(typeof(RubrumAbpKeycloakGraphqlModule))]
public class RubrumAbpKeycloakGraphqlTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var graphql = context.Services.GetGraphql();

        graphql
            .AddQueryType(d => d.Name(OperationTypeNames.Query))
            .AddMutationType(d => d.Name(OperationTypeNames.Mutation))
            .AddConvention<IFilterConvention>(new FilterConventionExtension(descriptor =>
            {
                descriptor.BindRuntimeType<Guid, IdOperationFilterInputType>();
            }))
            .ModifyRequestOptions(options =>
            {
                options.IncludeExceptionDetails = true;
            });
    }
}
