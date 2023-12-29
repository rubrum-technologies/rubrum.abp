namespace Rubrum.Abp.Keycloak;

public class AuthenticationDetails
{
    public string? RealmId { get; set; }

    public bool FlagRealmId { get; set; }

    public string? ClientId { get; set; }

    public bool FlagClientId { get; set; }

    public string? UserId { get; set; }

    public bool FlagUserId { get; set; }

    public string? IpAddress { get; set; }

    public bool FlagIpAddress { get; set; }
}
