namespace Rubrum.Abp.Keycloak;

public class AuthenticationExecutionExportRepresentation
{
    public string? AuthenticatorConfig { get; set; }
    public string? Authenticator { get; set; }
    public bool? AuthenticatorFlow { get; set; }
    public string? Requirement { get; set; }
    public int? Priority { get; set; }
    public bool? AutheticatorFlow { get; set; }
    public string? FlowAlias { get; set; }
    public bool? UserSetupAllowed { get; set; }
}
