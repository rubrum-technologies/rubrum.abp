using Volo.Abp.ObjectExtending.Modularity;

namespace Rubrum.Abp.LanguageManagement.ObjectExtending;

public class LanguageManagementModuleExtensionConfiguration : ModuleExtensionConfiguration
{
    public LanguageManagementModuleExtensionConfiguration ConfigureLanguage(
        Action<EntityExtensionConfiguration> configureAction)
    {
        return this.ConfigureEntity(
            LanguageManagementModuleExtensionConstants.EntityNames.SystemLanguage,
            configureAction
        );
    }
}
