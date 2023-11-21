using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using static Rubrum.Abp.LanguageManagement.LanguageConstants;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Rubrum.Abp.LanguageManagement;

public class Language : FullAuditedAggregateRoot<string>, IHasEntityVersion
{
    private string _name;

    protected Language()
    {
    }

    internal Language(string id, string name) : base(id)
    {
        Name = name;
    }

    public int EntityVersion { get; protected set; }

    public string Name
    {
        get => _name;
        internal set => _name = Check.NotNullOrWhiteSpace(value, nameof(value), MaxNameLenght);
    }
}
