using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.Model;

public class CountryType : ObjectType<Country>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(x => x.Id);
    }
}
