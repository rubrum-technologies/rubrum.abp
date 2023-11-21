using HotChocolate.Types;
using Volo.Abp.Data;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class HasExtraPropertiesType : InterfaceType<IHasExtraProperties>, IGraphqlType
{
    protected override void Configure(IInterfaceTypeDescriptor<IHasExtraProperties> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor
            .Field(x => x.ExtraProperties)
            .Type<JsonType>();
    }
}
