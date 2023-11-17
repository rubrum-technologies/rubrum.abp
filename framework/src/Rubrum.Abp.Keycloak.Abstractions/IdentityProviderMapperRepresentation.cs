namespace Rubrum.Abp.Keycloak;

public class IdentityProviderMapperRepresentation
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? IdentityProviderAlias { get; set; }
    public string? IdentityProviderMapper { get; set; }
    public Dictionary<string, string>? Config { get; set; }
}
