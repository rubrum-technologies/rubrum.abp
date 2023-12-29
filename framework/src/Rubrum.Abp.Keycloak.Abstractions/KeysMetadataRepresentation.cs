namespace Rubrum.Abp.Keycloak;

public class KeysMetadataRepresentation
{
    public Dictionary<string, string>? Active { get; set; }

    public List<KeyMetadataRepresentation>? Keys { get; set; }
}
