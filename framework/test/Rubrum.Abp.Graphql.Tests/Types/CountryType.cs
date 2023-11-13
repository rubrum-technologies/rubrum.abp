using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Graphql.Types;

public class CountryType : ObjectType<CountryDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<CountryDto> descriptor)
    {
        descriptor.Entity<CountryDto, Guid>();
        descriptor.FullAudited();
    }
}