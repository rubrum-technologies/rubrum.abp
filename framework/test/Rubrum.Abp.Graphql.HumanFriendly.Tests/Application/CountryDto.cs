using Rubrum.Abp.Ddd.HumanFriendly;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.HumanFriendly.Application;

public class CountryDto : FullAuditedEntityDto<Guid>, IHumanFriendlyId
{
    public long HumanFriendlyId { get; init; }

    public required string Name { get; init; }
}
