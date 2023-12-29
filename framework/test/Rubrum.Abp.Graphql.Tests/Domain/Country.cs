using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Rubrum.Abp.Graphql.Domain;

public class Country : FullAuditedAggregateRoot<Guid>
{
    public Country(Guid id, string name)
        : base(id)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }

    private Country()
    {
    }

    public string Name { get; set; }
}
