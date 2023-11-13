using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Application.Dtos;

public class CountryDto : FullAuditedEntityDto<Guid>
{
    public required string Name { get; init; }
}
