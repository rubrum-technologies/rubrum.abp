using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types.Root;

public class CityQueryType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityQuery<CityDto, int>("City", "City", "Cities", true);
    }
}
