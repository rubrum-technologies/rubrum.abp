namespace Rubrum.Abp.Keycloak;

public class ClientPolicyRepresentation
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Enabled { get; set; }
    public List<ClientPolicyConditionRepresentation>? Conditions { get; set; }
    public List<string>? Profiles { get; set; }
}
