namespace Rubrum.Abp.Keycloak;

public class SocialLinkRepresentation
{
    public string? SocialProvider { get; set; }

    public string? SocialUserId { get; set; }

    public string? SocialUsername { get; set; }
}
