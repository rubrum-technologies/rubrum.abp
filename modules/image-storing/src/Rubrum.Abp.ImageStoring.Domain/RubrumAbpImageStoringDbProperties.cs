using Rubrum.Abp.Data;

namespace Rubrum.Abp.ImageStoring;

public static class RubrumAbpImageStoringDbProperties
{
    public const string ConnectionStringName = "ImageStoring";

    public static string? DbTablePrefix { get; set; } = RubrumAbpCommonDbProperties.DbTablePrefix;

    public static string? DbSchema { get; set; } = RubrumAbpCommonDbProperties.DbSchema;
}
