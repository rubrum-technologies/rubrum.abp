namespace Rubrum.Abp.LanguageManagement.Permissions;

public static class LanguageManagementPermissions
{
    public const string GroupName = "LanguageManagement";

    public static class SystemLanguages
    {
        public const string Default = GroupName + ".SystemLanguages";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}
