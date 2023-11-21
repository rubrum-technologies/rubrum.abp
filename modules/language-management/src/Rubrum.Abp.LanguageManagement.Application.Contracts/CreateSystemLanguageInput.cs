namespace Rubrum.Abp.LanguageManagement;

public class CreateSystemLanguageInput : CreateOrUpdateSystemLanguageInputBase
{
    public required string Code { get; init; }
}
