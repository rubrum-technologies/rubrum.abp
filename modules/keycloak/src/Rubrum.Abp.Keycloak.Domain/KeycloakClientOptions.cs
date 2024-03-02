namespace Rubrum.Abp.Keycloak;

public class KeycloakClientOptions
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required string Secret { get; set; }

    public required string RootUrl { get; set; }

    public string[] Scopes { get; set; } = [];
}
