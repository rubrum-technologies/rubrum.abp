using Rubrum.Abp.Keycloak.Localization.Rubrum.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using static Rubrum.Abp.Keycloak.Permissions.KeycloakUserPermissions;

namespace Rubrum.Abp.Keycloak.Permissions;

public class KeycloakUserPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var group = context.AddGroup(GroupName, L("Permission:LanguageManagement"));

        var user =
            group.AddPermission(KeycloakUserPermissions.Users.Default, L("Permission:KeycloakUserManagement"));
        user.AddChild(KeycloakUserPermissions.Users.Create, L("Permission:Create"));
        user.AddChild(KeycloakUserPermissions.Users.Update, L("Permission:Update"));
        user.AddChild(KeycloakUserPermissions.Users.Delete, L("Permission:Delete"));
        user.AddChild(KeycloakUserPermissions.Users.ChangePassword, L("Permission:ChangePassword"));
        user.AddChild(KeycloakUserPermissions.Users.ChangeRoles, L("Permission:ChangeRoles"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RubrumAbpKeycloakResource>(name);
    }
}
