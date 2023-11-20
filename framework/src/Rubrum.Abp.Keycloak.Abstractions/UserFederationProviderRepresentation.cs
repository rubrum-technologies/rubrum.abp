namespace Rubrum.Abp.Keycloak;

public class UserFederationProviderRepresentation
{
    public string? Id { get; set; }
    public string? DisplayName { get; set; }
    public string? ProviderName { get; set; }
    public Dictionary<string, string>? Config { get; set; }
    public int? Priority { get; set; }
    public int? FullSyncPeriod { get; set; }
    public int? ChangedSyncPeriod { get; set; }
    public int? LastSync { get; set; }
}
