namespace Rubrum.Abp.Keycloak;

public class AuthenticatorConfigInfoRepresentation
{
    public string? Name { get; set; }

    public string? ProviderId { get; set; }

    public string? HelpText { get; set; }

    public List<ConfigPropertyRepresentation>? Properties { get; set; }
}
