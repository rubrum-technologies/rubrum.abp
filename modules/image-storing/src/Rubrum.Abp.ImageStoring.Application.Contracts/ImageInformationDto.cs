using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Rubrum.Abp.ImageStoring;

public class ImageInformationDto : ExtensibleFullAuditedEntityDto<Guid>, IHasEntityVersion
{
    public string? Tag { get; init; }

    public string? FileName { get; init; }

    public required string SystemFileName { get; init; }
    
    public bool IsDisposable { get; init; }
    
    public int EntityVersion { get; init; }
}
