namespace Rubrum.Abp.Keycloak;

public class IdentityProviderMapperTypeRepresentation
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? HelpText { get; set; }
    public List<ConfigPropertyRepresentation>? Properties { get; set; }
}
