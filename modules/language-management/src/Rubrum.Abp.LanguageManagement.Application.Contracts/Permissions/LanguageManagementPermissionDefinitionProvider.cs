using Rubrum.Abp.LanguageManagement.Localization.Rubrum.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using static Rubrum.Abp.LanguageManagement.Permissions.LanguageManagementPermissions;

namespace Rubrum.Abp.LanguageManagement.Permissions;

public class LanguageManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var group = context.AddGroup(GroupName, L("Permission:LanguageManagement"));

        var language = group.AddPermission(Languages.Default, L("Permission:LanguageManagement"));
        language.AddChild(Languages.Create, L("Permission:Create"));
        language.AddChild(Languages.Update, L("Permission:Update"));
        language.AddChild(Languages.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RubrumAbpLanguageManagementResource>(name);
    }
}
