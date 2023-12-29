using Rubrum.Abp.Data;

namespace Rubrum.Abp.LanguageManagement;

public static class RubrumAbpLanguageManagementDbProperties
{
    public const string ConnectionStringName = "RubrumAbpLanguageManagement";

    public static string? DbTablePrefix { get; set; } = RubrumAbpCommonDbProperties.DbTablePrefix;

    public static string? DbSchema { get; set; } = RubrumAbpCommonDbProperties.DbSchema;
}
