using HotChocolate.Types;
using Volo.Abp.Auditing;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class HasModificationTimeType : InterfaceType<IHasModificationTime>
{
    protected override void Configure(IInterfaceTypeDescriptor<IHasModificationTime> descriptor)
    {
        descriptor.Name("HasModificationTime");
        descriptor.Description("A standard interface to add DeletionTime property to a class.");

        descriptor.BindFieldsExplicitly();

        descriptor
            .Field(x => x.LastModificationTime)
            .Type<DateTimeType>();
    }
}