namespace Rubrum.Abp.Keycloak;

public class KeyMetadataRepresentation
{
    public string? ProviderId { get; set; }

    public long? ProviderPriority { get; set; }

    public string? Kid { get; set; }

    public string? Status { get; set; }

    public string? Type { get; set; }

    public string? Algorithm { get; set; }

    public string? PublicKey { get; set; }

    public string? Certificate { get; set; }

    public object? Use { get; set; }
}
