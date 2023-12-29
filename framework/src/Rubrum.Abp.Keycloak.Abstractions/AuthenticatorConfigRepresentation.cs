namespace Rubrum.Abp.Keycloak;

public class AuthenticatorConfigRepresentation
{
    public string? Id { get; set; }

    public string? Alias { get; set; }

    public Dictionary<string, string>? Config { get; set; }
}
