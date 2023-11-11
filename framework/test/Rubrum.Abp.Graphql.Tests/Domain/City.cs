using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Rubrum.Abp.Graphql.Domain;

public class City : FullAuditedAggregateRoot<int>
{
    private City()
    {
    }

    public City(int id, Guid countryId, string name) : base(id)
    {
        CountryId = countryId;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }

    public Guid CountryId { get; set; }

    public string Name { get; set; }
}