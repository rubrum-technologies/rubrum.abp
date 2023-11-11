using HotChocolate.Types;
using Volo.Abp.Auditing;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class HasDeletionTimeType : InterfaceType<IHasDeletionTime>
{
    protected override void Configure(IInterfaceTypeDescriptor<IHasDeletionTime> descriptor)
    {
        descriptor.Name("HasDeletionTime");
        descriptor.Description(
            "A standard interface to add DeletionTime property to a class. It also makes the class soft delete (see ISoftDelete).");

        descriptor.BindFieldsExplicitly();

        descriptor.Implements<SoftDeleteType>();

        descriptor
            .Field(x => x.DeletionTime)
            .Type<DateTimeType>();
    }
}