namespace Rubrum.Abp.Graphql.Extensions;

public static class HostBuilderExtensions
{
    public static bool IsGraphQlCommand(this string[] args)
    {
        return args is ["schema", ..];
    }
}
