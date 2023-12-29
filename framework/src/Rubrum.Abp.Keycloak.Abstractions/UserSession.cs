namespace Rubrum.Abp.Keycloak;

public class UserSession
{
    public string? Id { get; set; }

    public string? UserName { get; set; }

    public string? UserId { get; set; }

    public string? IpAddress { get; set; }

    public string? Start { get; set; }

    public long? LastAccess { get; set; }

    public IDictionary<string, string>? Clients { get; set; }
}
