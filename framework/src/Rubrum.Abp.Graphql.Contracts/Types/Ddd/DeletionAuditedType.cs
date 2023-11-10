using HotChocolate.Types;
using Volo.Abp.Auditing;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class DeletionAuditedType : InterfaceType<IDeletionAuditedObject>
{
    protected override void Configure(IInterfaceTypeDescriptor<IDeletionAuditedObject> descriptor)
    {
        descriptor.Name("DeletionAuditedObject");
        descriptor.Description(
            "This interface can be implemented to store deletion information (who delete and when deleted).");

        descriptor.BindFieldsExplicitly();

        descriptor.Implements<HasDeletionTimeType>();
        descriptor.Implements<SoftDeleteType>();

        descriptor
            .Field(x => x.DeleterId)
            .Type<IdType>();
    }
}
