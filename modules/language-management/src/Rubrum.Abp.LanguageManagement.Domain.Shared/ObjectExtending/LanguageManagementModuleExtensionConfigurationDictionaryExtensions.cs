using Volo.Abp.ObjectExtending.Modularity;

namespace Rubrum.Abp.LanguageManagement.ObjectExtending;

public static class LanguageManagementModuleExtensionConfigurationDictionaryExtensions
{
    public static ModuleExtensionConfigurationDictionary ConfigureLanguageManagement(
        this ModuleExtensionConfigurationDictionary modules,
        Action<LanguageManagementModuleExtensionConfiguration> configureAction)
    {
        return modules.ConfigureModule(
            LanguageManagementModuleExtensionConstants.ModuleName,
            configureAction);
    }
}
