using Volo.Abp.ObjectExtending.Modularity;

namespace Rubrum.Abp.ImageStoring.ObjectExtending;

public static class ImageStoringExtensionConfigurationDictionaryExtensions
{
    public static ModuleExtensionConfigurationDictionary ConfigureImageStoring(
        this ModuleExtensionConfigurationDictionary modules,
        Action<ImageStoringModuleExtensionConfiguration> configureAction)
    {
        return modules.ConfigureModule(
            ImageStoringModuleExtensionConstants.ModuleName,
            configureAction);
    }
}
