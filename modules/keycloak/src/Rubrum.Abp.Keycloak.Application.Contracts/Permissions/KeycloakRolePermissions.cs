namespace Rubrum.Abp.Keycloak.Permissions;

public static class KeycloakRolePermissions
{
    public const string GroupName = "KeycloakRoleManagement";

    public static class Roles
    {
        public const string Default = GroupName + ".Roles";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}
