using Rubrum.Abp.ImageStoring.Localization.Rubrum.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Rubrum.Abp.ImageStoring.Permissions;

public class RubrumAbpImageStoringPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var group = context.AddGroup(
            ImageStoringPermissions.GroupName,
            L("Permission:Images"));

        group.AddPermission(
            ImageStoringPermissions.Images.Upload,
            L("Permission:Upload"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RubrumAbpImageStoringResource>(name);
    }
}
