using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types.Ddd;
using Volo.Abp.TenantManagement;

namespace Rubrum.Abp.Graphql.Types;

public class TenantType : ObjectType<TenantDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<TenantDto> descriptor)
    {
        descriptor.Entity<TenantDto, Guid>();
        descriptor.ExtraProperties();
    }
}
