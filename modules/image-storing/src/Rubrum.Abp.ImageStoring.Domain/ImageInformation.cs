using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rubrum.Abp.ImageStoring;

public class ImageInformation : FullAuditedAggregateRoot<Guid>, IHasEntityVersion
{
    protected ImageInformation()
    {
    }

    internal ImageInformation(Guid id, string? tag = null) : base(id)
    {
        Tag = tag;
    }

    /// <summary>
    /// Признак группировки
    /// </summary>
    /// <remarks>
    /// Можно использовать в качестве идентификатора сущности с которой связанна данная группа
    /// </remarks>
    public string? Tag { get; internal set; }

    public string FileName => $"{Id}.webp";
    public int EntityVersion { get; protected set; }
}
