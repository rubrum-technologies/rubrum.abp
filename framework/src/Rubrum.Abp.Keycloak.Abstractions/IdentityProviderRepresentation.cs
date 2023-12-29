namespace Rubrum.Abp.Keycloak;

public class IdentityProviderRepresentation
{
    public string? Alias { get; set; }

    public string? DisplayName { get; set; }

    public string? InternalId { get; set; }

    public string? ProviderId { get; set; }

    public bool? Enabled { get; set; }

    public string? UpdateProfileFirstLoginMode { get; set; }

    public bool? TrustEmail { get; set; }

    public bool? StoreToken { get; set; }

    public bool? AddReadTokenRoleOnCreate { get; set; }

    public bool? AuthenticateByDefault { get; set; }

    public bool? LinkOnly { get; set; }

    public string? FirstBrokerLoginFlowAlias { get; set; }

    public string? PostBrokerLoginFlowAlias { get; set; }

    public Dictionary<string, string>? Config { get; set; }

    public bool? UpdateProfileFirstLogin { get; set; }
}
