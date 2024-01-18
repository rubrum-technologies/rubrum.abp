using HotChocolate.Types;
using Rubrum.Abp.Graphql.HumanFriendly.Application;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.HumanFriendly.Types.Root;

public class CountryQueryType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityQuery<CountryDto, Guid>(
            CountryConstants.TypeName,
            "Country",
            "Countries");

        descriptor.HumanFriendly<CountryDto, Guid>("Country");
    }
}
