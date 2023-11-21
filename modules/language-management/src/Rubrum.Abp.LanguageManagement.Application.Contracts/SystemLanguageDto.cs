using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageDto : ExtensibleFullAuditedEntityDto<string>
{
    public required string Name { get; init; }
}
