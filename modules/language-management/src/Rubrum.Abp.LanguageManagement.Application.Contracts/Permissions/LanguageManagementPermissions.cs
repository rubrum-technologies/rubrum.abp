namespace Rubrum.Abp.LanguageManagement.Permissions;

public static class LanguageManagementPermissions
{
    public const string GroupName = "LanguageManagement";

    public static class Languages
    {
        public const string Default = GroupName + ".Languages";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}
