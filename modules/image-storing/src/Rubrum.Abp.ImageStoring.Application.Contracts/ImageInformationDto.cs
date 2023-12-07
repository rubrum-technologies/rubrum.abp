using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.ImageStoring;

public class ImageInformationDto : ExtensibleEntityDto<Guid>
{
    public string? Tag { get; init; }
}
