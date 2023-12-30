using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Volo.Abp.TenantManagement;

namespace Rubrum.Abp.Graphql.Types;

[ExtendObjectType(OperationType.Query)]
public class TenantQuery : IGraphqlType
{
    [GraphQLName("tenantById")]
    public Task<TenantDto> GetByIdAsync([ID("Tenant")] Guid id, [Service] ITenantAppService service)
    {
        return service.GetAsync(id);
    }
}
