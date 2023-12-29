namespace Rubrum.Abp.Keycloak;

public class FederatedIdentityRepresentation
{
    public string? IdentityProvider { get; set; }

    public string? UserId { get; set; }

    public string? UserName { get; set; }
}
