namespace Rubrum.Abp.Graphql.Model;

public class Country
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}