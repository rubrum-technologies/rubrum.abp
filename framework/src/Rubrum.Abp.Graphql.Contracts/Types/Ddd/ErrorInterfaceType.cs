using HotChocolate.Types;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class ErrorInterfaceType : InterfaceType
{
    protected override void Configure(IInterfaceTypeDescriptor descriptor)
    {
        descriptor.Name("Error");

        descriptor
            .Field("message")
            .Type<NonNullType<StringType>>();
    }
}