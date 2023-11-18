namespace Rubrum.Abp.Keycloak;

public class KeycloakEvent
{
    public string? ClientId { get; set; }
    public IDictionary<string, object>? Details { get; set; }
    public string? Error { get; set; }
    public string? IpAddress { get; set; }
    public string? RealmId { get; set; }
    public string? SessionId { get; set; }
    public long? Time { get; set; }
    public string? Type { get; set; }
    public string? UserId { get; set; }
}
