using Volo.Abp.ObjectExtending.Modularity;

namespace Rubrum.Abp.ImageStoring.ObjectExtending;

public class ImageStoringModuleExtensionConfiguration : ModuleExtensionConfiguration
{
    public ImageStoringModuleExtensionConfiguration ConfigureImageInformation(
        Action<EntityExtensionConfiguration> configureAction)
    {
        return this.ConfigureEntity(
            ImageStoringModuleExtensionConstants.EntityNames.ImageInformation,
            configureAction);
    }
}
