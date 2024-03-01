using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[DependsOn(typeof(AbpPermissionManagementApplicationModule))]
[DependsOn(typeof(RubrumAbpGraphqlModule))]
[DependsOn(typeof(RubrumAbpPermissionManagementGraphqlContractsModule))]
public class RubrumAbpPermissionManagementGraphqlModule : AbpModule;
