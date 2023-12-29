namespace Rubrum.Abp.Keycloak;

public class UserRepresentation
{
    public string? Self { get; set; }

    public string? Id { get; set; }

    public string? Origin { get; set; }

    public long? CreatedTimestamp { get; set; }

    public string? Username { get; set; }

    public bool? Enabled { get; set; }

    public bool? Totp { get; set; }

    public bool? EmailVerified { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? FederationLink { get; set; }

    public string? ServiceAccountClientId { get; set; }

    public Dictionary<string, List<object>>? Attributes { get; set; }

    public List<CredentialRepresentation>? Credentials { get; set; }

    public List<string>? DisableableCredentialTypes { get; set; }

    public List<string>? RequiredActions { get; set; }

    public List<FederatedIdentityRepresentation>? FederatedIdentities { get; set; }

    public List<string>? RealmRoles { get; set; }

    public Dictionary<string, List<object>>? ClientRoles { get; set; }

    public List<UserConsentRepresentation>? ClientConsents { get; set; }

    public int? NotBefore { get; set; }

    public Dictionary<string, List<object>>? ApplicationRoles { get; set; }

    public List<SocialLinkRepresentation>? SocialLinks { get; set; }

    public List<string>? Groups { get; set; }

    public Dictionary<string, bool>? Access { get; set; }
}
