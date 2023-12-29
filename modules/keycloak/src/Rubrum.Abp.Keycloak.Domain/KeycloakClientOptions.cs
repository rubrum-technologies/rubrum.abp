namespace Rubrum.Abp.Keycloak;

#nullable disable

public class KeycloakClientOptions
{
    public string Name { get; set; }

    public string Secret { get; set; }

    public string RootUrl { get; set; }

    public string[] Scopes { get; set; }
}
