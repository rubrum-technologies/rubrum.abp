using Rubrum.Abp.Keycloak.Localization.Rubrum.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using static Rubrum.Abp.Keycloak.Permissions.KeycloakRolePermissions;

namespace Rubrum.Abp.Keycloak.Permissions;

public class KeycloakRolePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var group = context.AddGroup(GroupName, L("Permission:KeycloakRoleManagement"));

        var role = group.AddPermission(KeycloakRolePermissions.Roles.Default, L("Permission:KeycloakRoleManagement"));
        role.AddChild(KeycloakRolePermissions.Roles.Create, L("Permission:Create"));
        role.AddChild(KeycloakRolePermissions.Roles.Update, L("Permission:Update"));
        role.AddChild(KeycloakRolePermissions.Roles.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RubrumAbpKeycloakResource>(name);
    }
}
