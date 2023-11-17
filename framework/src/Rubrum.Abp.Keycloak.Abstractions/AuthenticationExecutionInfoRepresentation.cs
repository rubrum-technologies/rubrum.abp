namespace Rubrum.Abp.Keycloak;

public class AuthenticationExecutionInfoRepresentation
{
    public string? Id { get; set; }
    public string? Requirement { get; set; }
    public string? DisplayName { get; set; }
    public string? Alias { get; set; }
    public string? Description { get; set; }
    public List<string>? RequirementChoices { get; set; }
    public bool? Configurable { get; set; }
    public bool? AuthenticationFlow { get; set; }
    public string? ProviderId { get; set; }
    public string? AuthenticationConfig { get; set; }
    public string? FlowId { get; set; }
    public int? Level { get; set; }
    public int? Index { get; set; }
}
