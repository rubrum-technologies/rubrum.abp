using HotChocolate.Types;
using Volo.Abp.Auditing;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class ModificationAuditedType : InterfaceType<IModificationAuditedObject>
{
    protected override void Configure(IInterfaceTypeDescriptor<IModificationAuditedObject> descriptor)
    {
        descriptor.Name("ModificationAuditedObject");
        descriptor.Description(
            "This interface can be implemented to store modification information (who and when modified lastly).");

        descriptor.BindFieldsExplicitly();

        descriptor.Implements<HasModificationTimeType>();

        descriptor
            .Field(x => x.LastModifierId)
            .Type<IdType>();
    }
}