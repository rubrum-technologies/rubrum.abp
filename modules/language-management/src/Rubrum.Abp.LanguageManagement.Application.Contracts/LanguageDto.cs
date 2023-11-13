using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageDto : FullAuditedEntityDto<string>
{
    public required string Name { get; init; }
}
