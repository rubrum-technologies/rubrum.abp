namespace Rubrum.Abp.Graphql.Types;

public class EntityMutationOptions
{
    public required string TypeName { get; init; }

    public required string TypeNameSingular { get; init; }

    public bool IsAuthorize { get; init; } = true;
}
