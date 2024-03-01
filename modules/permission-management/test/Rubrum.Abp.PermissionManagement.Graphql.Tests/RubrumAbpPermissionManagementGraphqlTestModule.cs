using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql;
using Rubrum.Abp.Graphql.Extensions;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.PermissionManagement;

[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(RubrumAbpGraphqlTestBaseModule))]
[DependsOn(typeof(RubrumAbpPermissionManagementGraphqlModule))]
public class RubrumAbpPermissionManagementGraphqlTestModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<RubrumAbpGraphqlOptions>(options =>
        {
            options.EnableGlobalObjectIdentification = false;
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAlwaysAllowAuthorization();

        var graphql = context.Services.GetGraphql();

        graphql
            .AddQueryType(d => d.Name(OperationTypeNames.Query))
            .AddFakeAuthorizationHandler();
    }
}
