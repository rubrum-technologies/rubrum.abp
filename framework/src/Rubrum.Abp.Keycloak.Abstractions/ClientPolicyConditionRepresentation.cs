namespace Rubrum.Abp.Keycloak;

public class ClientPolicyConditionRepresentation
{
    public string? Condition { get; set; }
    public List<object>? Configuration { get; set; }
}
