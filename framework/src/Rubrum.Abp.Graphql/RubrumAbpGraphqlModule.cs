using HotChocolate.Data.Filters.Expressions;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.Graphql.Filters.DateOnly;
using Rubrum.Abp.Graphql.Interceptors;
using Rubrum.Abp.Graphql.Types.Ddd;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql;

[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(typeof(RubrumAbpGraphqlContractsModule))]
public class RubrumAbpGraphqlModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddConventionalRegistrar(new GraphqlServiceConventionalRegistrar());
        var options = context.Services.ExecutePreConfiguredActions<RubrumAbpGraphqlOptions>();

        var graphql = context.Services
            .AddGraphQL()
            .AddGraphQLServer();

        graphql
            .AddAuthorization()
            .AddMutationConventions()
            .AddFiltering(descriptor =>
            {
                descriptor.AddDefaultOperations();
                descriptor.BindDefaultTypes();

                descriptor.Provider(new QueryableFilterProvider(provider =>
                {
                    provider.AddFieldHandler<QueryableDateOnlyEqualsHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyGreaterThanHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyGreaterThanOrEqualsHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyInHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyLowerThanHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyLowerThanOrEqualsHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyNotEqualsHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyNotGreaterThanHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyNotGreaterThanOrEqualsHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyNotInHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyNotLowerThanHandler>();
                    provider.AddFieldHandler<QueryableDateOnlyNotLowerThanOrEqualsHandler>();

                    provider.AddDefaultFieldHandlers();
                }));
            })
            .AddSorting()
            .AddProjections()
            .AddErrorInterfaceType<ErrorInterfaceType>()
            .TryAddTypeInterceptor<DtoTypeInterceptor>()
            .RegisterGraphqlTypes()
            .RegisterDataLoaders();

        if (options.EnableGlobalObjectIdentification)
        {
            graphql.AddGlobalObjectIdentification();
        }

        context.Services.AddSingleton(graphql);
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        var graphql = context.Services.GetGraphql();

        graphql.TryAddTypeInterceptor<NewLineTypeInterceptor>();
    }
}
