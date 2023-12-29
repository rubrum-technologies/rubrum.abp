namespace Rubrum.Abp.Keycloak;

public class RolesRepresentation
{
    public List<RoleRepresentation>? Realm { get; set; }

    public Dictionary<string, List<object>>? Client { get; set; }

    public Dictionary<string, List<object>>? Application { get; set; }
}
