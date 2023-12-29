namespace Rubrum.Abp.Keycloak;

public class AuthenticationExecutionRepresentation
{
    public string? AuthenticatorConfig { get; set; }

    public string? Authenticator { get; set; }

    public bool? AuthenticatorFlow { get; set; }

    public string? Requirement { get; set; }

    public int? Priority { get; set; }

    public bool? AutheticatorFlow { get; set; }

    public string? Id { get; set; }

    public string? FlowId { get; set; }

    public string? ParentFlow { get; set; }
}
