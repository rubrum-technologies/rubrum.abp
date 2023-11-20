namespace Rubrum.Abp.Keycloak.Permissions;

public static class KeycloakUserPermissions
{
    public const string GroupName = "KeycloakUserManagement";

    public static class Users
    {
        public const string Default = GroupName + ".Users";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string ChangePassword = Default + ".ChangePassword";
        public const string ChangeRoles = Default + ".ChangeRoles";
    }
}
