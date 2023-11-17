namespace Rubrum.Abp.Keycloak;

public class KeyStoreConfig
{
    public bool? RealmCertificate { get; set; }
    public string? StorePassword { get; set; }
    public string? KeyPassword { get; set; }
    public string? KeyAlias { get; set; }
    public string? RealmAlias { get; set; }
    public string? Format { get; set; }
}
