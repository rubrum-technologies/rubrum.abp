using Volo.Abp.ObjectExtending;

namespace Rubrum.Abp.LanguageManagement;

public abstract class CreateOrUpdateSystemLanguageInputBase : ExtensibleObject
{
    public required string Name { get; init; }
}
