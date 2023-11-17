namespace Rubrum.Abp.Keycloak;

public class AuthenticationFlowRepresentation
{
    public string? Id { get; set; }
    public string? Alias { get; set; }
    public string? Description { get; set; }
    public string? ProviderId { get; set; }
    public bool? TopLevel { get; set; }
    public bool? BuiltIn { get; set; }
    public List<AuthenticationExecutionExportRepresentation>? AuthenticationExecutions { get; set; }
}
