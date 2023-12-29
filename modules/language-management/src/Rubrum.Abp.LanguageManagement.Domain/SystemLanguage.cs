using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using static Rubrum.Abp.LanguageManagement.SystemLanguageConstants;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguage : FullAuditedAggregateRoot<string>, IHasEntityVersion
{
    private string _name;

    internal SystemLanguage(string id, string name)
        : base(id)
    {
        Name = name;
    }

    protected SystemLanguage()
    {
    }

    public string Name
    {
        get => _name;
        internal set => _name = Check.NotNullOrWhiteSpace(value, nameof(value), MaxNameLenght);
    }

    public int EntityVersion { get; protected set; }
}
