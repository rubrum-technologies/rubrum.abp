using HotChocolate.Types;
using Volo.Abp.Auditing;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class HasCreationTimeType : InterfaceType<IHasCreationTime>
{
    protected override void Configure(IInterfaceTypeDescriptor<IHasCreationTime> descriptor)
    {
        descriptor.Name("HasCreationTime");
        descriptor.Description("A standard interface to add CreationTime property.");

        descriptor.BindFieldsExplicitly();

        descriptor
            .Field(x => x.CreationTime)
            .Type<DateTimeType>();
    }
}