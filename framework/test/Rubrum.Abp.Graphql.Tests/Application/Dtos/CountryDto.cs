using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Application.Dtos;

public class CountryDto : EntityDto<Guid>
{
    public required string Name { get; init; }
}