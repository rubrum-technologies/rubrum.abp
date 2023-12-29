namespace Rubrum.Abp.Keycloak;

public class AdminEvent
{
    public AuthenticationDetails? AuthDetails { get; set; }

    public string? Error { get; set; }

    public string? OperationType { get; set; }

    public string? RealmId { get; set; }

    public string? Representation { get; set; }

    public string? ResourcePath { get; set; }

    public string? ResourceType { get; set; }

    public long? Time { get; set; }
}
