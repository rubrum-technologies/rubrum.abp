namespace Rubrum.Abp.Graphql.Types;

public class EntityQueryOptions
{
    public required string TypeName { get; init; }

    public required string TypeNameSingular { get; init; }

    public required string TypeNameInPlural { get; init; }

    public bool IsAuthorize { get; init; } = true;

    public bool IsAddFieldByAll { get; init; } = false;
}
