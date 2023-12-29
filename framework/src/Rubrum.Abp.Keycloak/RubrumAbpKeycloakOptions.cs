namespace Rubrum.Abp.Keycloak;

#nullable disable

public class RubrumAbpKeycloakOptions
{
    public string Url { get; set; }

    public string AdminUserName { get; set; }

    public string AdminPassword { get; set; }

    public string AdminClientId { get; set; } = "admin-cli";

    public string DefaultRealmName { get; set; }
}
