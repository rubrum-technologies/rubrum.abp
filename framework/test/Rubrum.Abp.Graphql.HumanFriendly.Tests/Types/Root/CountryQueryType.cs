using HotChocolate.Types;
using Rubrum.Abp.Graphql.HumanFriendly.Application;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.HumanFriendly.Types.Root;

public class CountryQueryType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityQuery<CountryDto, Guid>(new EntityQueryOptions
        {
            TypeName = CountryConstants.TypeName,
            TypeNameSingular = "Country",
            TypeNameInPlural = "Countries",
            IsAuthorize = false
        });

        descriptor.HumanFriendly<CountryDto, Guid>("Country");
    }
}
