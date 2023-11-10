using HotChocolate.Types;
using Volo.Abp.MultiTenancy;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class MultiTenantType : InterfaceType<IMultiTenant>
{
    protected override void Configure(IInterfaceTypeDescriptor<IMultiTenant> descriptor)
    {
        descriptor.Name("MultiTenant");

        descriptor.BindFieldsExplicitly();

        descriptor
            .Field(x => x.TenantId)
            .Type<IdType>();
    }
}
