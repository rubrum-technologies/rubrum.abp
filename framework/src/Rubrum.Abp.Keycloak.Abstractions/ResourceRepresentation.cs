namespace Rubrum.Abp.Keycloak;

public class ResourceRepresentation
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<string>? Uris { get; set; }

    public string? Type { get; set; }

    public List<ScopeRepresentation>? Scopes { get; set; }

    public string? IconUri { get; set; }

    public ResourceRepresentationOwner? Owner { get; set; }

    public bool? OwnerManagedAccess { get; set; }

    public string? DisplayName { get; set; }

    public Dictionary<string, List<object>>? Attributes { get; set; }

    public string? Uri { get; set; }

    public List<ScopeRepresentation>? ScopesUma { get; set; }
}
