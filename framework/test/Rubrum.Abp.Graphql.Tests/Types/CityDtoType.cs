using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Graphql.Types;

public class CityDtoType : ObjectType<CityDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<CityDto> descriptor)
    {
        descriptor.Entity<CityDto, int>();
        descriptor.FullAudited();
    }
}