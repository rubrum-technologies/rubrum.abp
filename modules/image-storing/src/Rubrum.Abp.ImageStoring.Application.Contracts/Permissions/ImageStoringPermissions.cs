using Volo.Abp.Reflection;

namespace Rubrum.Abp.ImageStoring.Permissions;

public static class ImageStoringPermissions
{
    public const string GroupName = "ImageStoring";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ImageStoringPermissions));
    }

    public static class Images
    {
        public const string Upload = GroupName + ".Upload";
    }
}
