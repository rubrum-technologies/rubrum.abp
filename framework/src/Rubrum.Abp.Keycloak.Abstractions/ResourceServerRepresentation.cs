namespace Rubrum.Abp.Keycloak;

public class ResourceServerRepresentation
{
    public string? Id { get; set; }

    public string? ClientId { get; set; }

    public string? Name { get; set; }

    public bool? AllowRemoteResourceManagement { get; set; }

    public object? PolicyEnforcementMode { get; set; }

    public List<ResourceRepresentation>? Resources { get; set; }

    public List<PolicyRepresentation>? Policies { get; set; }

    public List<ScopeRepresentation>? Scopes { get; set; }

    public object? DecisionStrategy { get; set; }
}
