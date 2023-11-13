namespace Rubrum.Abp.LanguageManagement;

public class CreateLanguageInput : CreateOrUpdateLanguageInputBase
{
    public required string Code { get; init; }
}
