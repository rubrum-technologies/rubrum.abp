using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Application.Dtos;

public class CityDto : FullAuditedEntityDto<int>
{
    public required Guid CountryId { get; init; }
    public required string Name { get; init; }
}