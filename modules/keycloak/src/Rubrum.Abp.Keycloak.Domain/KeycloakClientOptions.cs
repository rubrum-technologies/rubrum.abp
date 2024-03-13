namespace Rubrum.Abp.Keycloak;

public class KeycloakClientOptions : ClientRepresentation
{
    public KeycloakClientOptions()
    {
        Enabled = true;
        Protocol = "openid-connect";
    }

    public string[] Scopes { get; set; } = [];
}
