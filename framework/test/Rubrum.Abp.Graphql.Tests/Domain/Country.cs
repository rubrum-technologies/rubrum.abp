using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rubrum.Abp.Graphql.Domain;

public class Country : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; }

    public Country(Guid id, string name) : base(id)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }
}