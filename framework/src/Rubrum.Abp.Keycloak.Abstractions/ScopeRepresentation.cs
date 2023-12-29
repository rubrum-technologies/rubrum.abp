namespace Rubrum.Abp.Keycloak;

public class ScopeRepresentation
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? IconUri { get; set; }

    public List<PolicyRepresentation>? Policies { get; set; }

    public List<ResourceRepresentation>? Resources { get; set; }

    public string? DisplayName { get; set; }
}
