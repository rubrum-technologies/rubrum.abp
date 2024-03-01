using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Language;
using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[ExtendObjectType(OperationType.Query)]
public class PermissionQuery : IGraphqlType
{
    [Authorize]
    [GraphQLName("permissions")]
    public Task<GetPermissionListResultDto> GetAsync(
        string providerName,
        string providerKey,
        [Service] IPermissionAppService service)
    {
        return service.GetAsync(providerName, providerKey);
    }
}
