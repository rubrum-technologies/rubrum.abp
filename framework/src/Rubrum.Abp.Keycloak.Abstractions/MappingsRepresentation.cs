namespace Rubrum.Abp.Keycloak;

public class MappingsRepresentation
{
    public List<RoleRepresentation>? RealmMappings { get; set; }

    public Dictionary<string, ClientMappingsRepresentation>? ClientMappings { get; set; }
}
