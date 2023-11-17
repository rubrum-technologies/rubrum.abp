namespace Rubrum.Abp.Keycloak;

public class GroupRepresentation
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Path { get; set; }
    public Dictionary<string, List<object>>? Attributes { get; set; }
    public List<string>? RealmRoles { get; set; }
    public Dictionary<string, List<object>>? ClientRoles { get; set; }
    public List<GroupRepresentation>? SubGroups { get; set; }
    public Dictionary<string, bool>? Access { get; set; }
}
