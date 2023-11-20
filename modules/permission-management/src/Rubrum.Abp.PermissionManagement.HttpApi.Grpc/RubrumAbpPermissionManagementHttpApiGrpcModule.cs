using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[DependsOn(typeof(AbpPermissionManagementApplicationModule))]
public class RubrumAbpPermissionManagementHttpApiGrpcModule : AbpModule
{
}
