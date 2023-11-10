using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rubrum.Abp.Graphql.Domain;

public class City : FullAuditedAggregateRoot<int>
{
    public Guid CountryId { get; }
    
    public string Name { get; }

    public City(int id, Guid countryId, string name) : base(id)
    {
        CountryId = countryId;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }
}