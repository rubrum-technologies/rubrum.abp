using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types.Root;

public class CountryQueryType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityQuery<CountryDto, Guid>(new EntityQueryOptions
        {
            TypeName = CountryConstants.TypeName,
            TypeNameSingular = "Country",
            TypeNameInPlural = "Countries"
        });
    }
}
