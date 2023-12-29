namespace Rubrum.Abp.Keycloak;

public class PolicyRepresentation
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public List<string>? Policies { get; set; }

    public List<string>? Resources { get; set; }

    public List<string>? Scopes { get; set; }

    public object? Logic { get; set; }

    public object? DecisionStrategy { get; set; }

    public string? Owner { get; set; }

    public List<ResourceRepresentation>? ResourcesData { get; set; }

    public List<ScopeRepresentation>? ScopesData { get; set; }

    public Dictionary<string, string>? Config { get; set; }
}
