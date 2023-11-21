using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageDto : ExtensibleFullAuditedEntityDto<string>
{
    public required string Name { get; init; }
}
