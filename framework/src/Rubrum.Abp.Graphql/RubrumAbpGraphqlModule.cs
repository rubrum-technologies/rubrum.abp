using HotChocolate.Configuration;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.Graphql.Filters.DateOnly;
using Rubrum.Abp.Graphql.Interceptors;
using Rubrum.Abp.Graphql.Types.Ddd;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(RubrumAbpGraphqlContractsModule))]
public class RubrumAbpGraphqlModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var graphql = context.Services
            .AddGraphQL()
            .AddGraphQLServer();

        graphql
            .AddAuthorization()
            .AddGlobalObjectIdentification()
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
            .AddConvention<IFilterConvention>(new FilterConventionExtension(descriptor =>
            {
                descriptor.BindRuntimeType<Guid, IdOperationFilterInputType>();
            }))
            .AddErrorInterfaceType<ErrorInterfaceType>()
            .TryAddTypeInterceptor<DtoTypeInterceptor>()
            .ModifyOptions(options =>
            {
                options.UseXmlDocumentation = true;
                options.SortFieldsByName = true;
                options.EnableDirectiveIntrospection = true;
                options.DefaultDirectiveVisibility = DirectiveVisibility.Public;
                options.StrictValidation = true;
                options.EnableOneOf = true;
            })
            .RegisterGraphqlTypes()
            .RegisterGraphqlServices()
            .RegisterDataLoaders();

        context.Services.AddSingleton(graphql);
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        var graphql = context.Services.GetGraphql();
        graphql.InitializeOnStartup();
    }
}