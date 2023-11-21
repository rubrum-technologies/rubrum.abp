using Volo.Abp.ObjectExtending;

namespace Rubrum.Abp.LanguageManagement;

public abstract class CreateOrUpdateLanguageInputBase : ExtensibleObject
{
    public required string Name { get; init; }
}
