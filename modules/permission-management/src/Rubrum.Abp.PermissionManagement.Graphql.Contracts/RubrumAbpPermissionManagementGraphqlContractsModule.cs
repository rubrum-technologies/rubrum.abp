using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[DependsOn(typeof(AbpPermissionManagementApplicationContractsModule))]
[DependsOn(typeof(RubrumAbpGraphqlContractsModule))]
public class RubrumAbpPermissionManagementGraphqlContractsModule : AbpModule;
