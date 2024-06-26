﻿using HotChocolate.Data.Filters;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.ImageStoring.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(RubrumAbpGraphqlTestBaseModule))]
[DependsOn(typeof(RubrumAbpImageStoringEntityFrameworkCoreTestModule))]
[DependsOn(typeof(RubrumAbpImageStoringGraphqlModule))]
public class RubrumAbpImageStoringGraphqlTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var graphql = context.Services.GetGraphql();

        graphql
            .AddQueryType(d => d.Name(OperationTypeNames.Query))
            .AddConvention<IFilterConvention>(new FilterConventionExtension(descriptor =>
            {
                descriptor.BindRuntimeType<Guid, IdOperationFilterInputType>();
            }))
            .ModifyRequestOptions(options =>
            {
                options.IncludeExceptionDetails = true;
            })
            .AddFakeAuthorizationHandler();
    }
}
