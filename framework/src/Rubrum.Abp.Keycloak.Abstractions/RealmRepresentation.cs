using System.Text.Json.Serialization;

namespace Rubrum.Abp.Keycloak;

public class RealmRepresentation
{
    public string? Id { get; set; }
    public string? Realm { get; set; }
    public string? DisplayName { get; set; }
    public string? DisplayNameHtml { get; set; }
    public int? NotBefore { get; set; }
    public string? DefaultSignatureAlgorithm { get; set; }
    public bool? RevokeRefreshToken { get; set; }
    public int? RefreshTokenMaxReuse { get; set; }
    public int? AccessTokenLifespan { get; set; }
    public int? AccessTokenLifespanForImplicitFlow { get; set; }
    public int? SsoSessionIdleTimeout { get; set; }
    public int? SsoSessionMaxLifespan { get; set; }
    public int? SsoSessionIdleTimeoutRememberMe { get; set; }
    public int? SsoSessionMaxLifespanRememberMe { get; set; }
    public int? OfflineSessionIdleTimeout { get; set; }
    public bool? OfflineSessionMaxLifespanEnabled { get; set; }
    public int? OfflineSessionMaxLifespan { get; set; }
    public int? ClientSessionIdleTimeout { get; set; }
    public int? ClientSessionMaxLifespan { get; set; }
    public int? ClientOfflineSessionIdleTimeout { get; set; }
    public int? ClientOfflineSessionMaxLifespan { get; set; }
    public int? AccessCodeLifespan { get; set; }
    public int? AccessCodeLifespanUserAction { get; set; }
    public int? AccessCodeLifespanLogin { get; set; }
    public int? ActionTokenGeneratedByAdminLifespan { get; set; }
    public int? ActionTokenGeneratedByUserLifespan { get; set; }

    [JsonPropertyName("oauth2DeviceCodeLifespan")]
    public int? OAuth2DeviceCodeLifespan { get; set; }

    [JsonPropertyName("oauth2DevicePollingInterval")]
    public int? OAuth2DevicePollingInterval { get; set; }

    public bool? Enabled { get; set; }
    public string? SslRequired { get; set; }
    public bool? PasswordCredentialGrantAllowed { get; set; }
    public bool? RegistrationAllowed { get; set; }
    public bool? RegistrationEmailAsUsername { get; set; }
    public bool? RememberMe { get; set; }
    public bool? VerifyEmail { get; set; }
    public bool? LoginWithEmailAllowed { get; set; }
    public bool? DuplicateEmailsAllowed { get; set; }
    public bool? ResetPasswordAllowed { get; set; }
    public bool? EditUsernameAllowed { get; set; }
    public bool? UserCacheEnabled { get; set; }
    public bool? RealmCacheEnabled { get; set; }
    public bool? BruteForceProtected { get; set; }
    public bool? PermanentLockout { get; set; }
    public int? MaxFailureWaitSeconds { get; set; }
    public int? MinimumQuickLoginWaitSeconds { get; set; }
    public int? WaitIncrementSeconds { get; set; }
    public long QuickLoginCheckMilliSeconds { get; set; }
    public int? MaxDeltaTimeSeconds { get; set; }
    public int? FailureFactor { get; set; }
    public string? PrivateKey { get; set; }
    public string? PublicKey { get; set; }
    public string? Certificate { get; set; }
    public string? CodeSecret { get; set; }
    public RolesRepresentation? Roles { get; set; }
    public List<GroupRepresentation>? Groups { get; set; }
    public List<string>? DefaultRoles { get; set; }
    public RoleRepresentation? DefaultRole { get; set; }
    public List<string>? DefaultGroups { get; set; }
    public List<string>? RequiredCredentials { get; set; }
    public string? PasswordPolicy { get; set; }
    public string? OtpPolicyType { get; set; }
    public string? OtpPolicyAlgorithm { get; set; }
    public int? OtpPolicyInitialCounter { get; set; }
    public int? OtpPolicyDigits { get; set; }
    public int? OtpPolicyLookAheadWindow { get; set; }
    public int? OtpPolicyPeriod { get; set; }
    public bool? OtpPolicyCodeReusable { get; set; }
    public List<string>? OtpSupportedApplications { get; set; }
    public string? WebAuthnPolicyRpEntityName { get; set; }
    public List<string>? WebAuthnPolicySignatureAlgorithms { get; set; }
    public string? WebAuthnPolicyRpId { get; set; }
    public string? WebAuthnPolicyAttestationConveyancePreference { get; set; }
    public string? WebAuthnPolicyAuthenticatorAttachment { get; set; }
    public string? WebAuthnPolicyRequireResidentKey { get; set; }
    public string? WebAuthnPolicyUserVerificationRequirement { get; set; }
    public int? WebAuthnPolicyCreateTimeout { get; set; }
    public bool? WebAuthnPolicyAvoidSameAuthenticatorRegister { get; set; }
    public List<string>? WebAuthnPolicyAcceptableAaguids { get; set; }
    public string? WebAuthnPolicyPasswordlessRpEntityName { get; set; }
    public List<string>? WebAuthnPolicyPasswordlessSignatureAlgorithms { get; set; }
    public string? WebAuthnPolicyPasswordlessRpId { get; set; }
    public string? WebAuthnPolicyPasswordlessAttestationConveyancePreference { get; set; }
    public string? WebAuthnPolicyPasswordlessAuthenticatorAttachment { get; set; }
    public string? WebAuthnPolicyPasswordlessRequireResidentKey { get; set; }
    public string? WebAuthnPolicyPasswordlessUserVerificationRequirement { get; set; }
    public int? WebAuthnPolicyPasswordlessCreateTimeout { get; set; }
    public bool? WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; set; }
    public List<string>? WebAuthnPolicyPasswordlessAcceptableAaguids { get; set; }
    public RealmClientProfiles? ClientProfiles { get; set; }
    public RealmClientPolicies? ClientPolicies { get; set; }
    public List<UserRepresentation>? Users { get; set; }
    public List<UserRepresentation>? FederatedUsers { get; set; }
    public List<ScopeMappingRepresentation>? ScopeMappings { get; set; }
    public Dictionary<string, List<object>>? ClientScopeMappings { get; set; }
    public List<ClientRepresentation>? Clients { get; set; }
    public List<ClientScopeRepresentation>? ClientScopes { get; set; }
    public List<string>? DefaultDefaultClientScopes { get; set; }
    public List<string>? DefaultOptionalClientScopes { get; set; }
    public Dictionary<string, string>? BrowserSecurityHeaders { get; set; }
    public Dictionary<string, string>? SmtpServer { get; set; }
    public List<UserFederationProviderRepresentation>? UserFederationProviders { get; set; }
    public List<UserFederationMapperRepresentation>? UserFederationMappers { get; set; }
    public string? LoginTheme { get; set; }
    public string? AccountTheme { get; set; }
    public string? AdminTheme { get; set; }
    public string? EmailTheme { get; set; }
    public bool? EventsEnabled { get; set; }
    public long? EventsExpiration { get; set; }
    public List<string>? EventsListeners { get; set; }
    public List<string>? EnabledEventTypes { get; set; }
    public bool? AdminEventsEnabled { get; set; }
    public bool? AdminEventsDetailsEnabled { get; set; }
    public List<IdentityProviderRepresentation>? IdentityProviders { get; set; }
    public List<IdentityProviderMapperRepresentation>? IdentityProviderMappers { get; set; }
    public List<ProtocolMapperRepresentation>? ProtocolMappers { get; set; }
    public Dictionary<string, List<object>>? Components { get; set; }
    public bool? InternationalizationEnabled { get; set; }
    public List<string>? SupportedLocales { get; set; }
    public string? DefaultLocale { get; set; }
    public List<AuthenticationFlowRepresentation>? AuthenticationFlows { get; set; }
    public List<AuthenticatorConfigRepresentation>? AuthenticatorConfig { get; set; }
    public List<RequiredActionProviderRepresentation>? RequiredActions { get; set; }
    public string? BrowserFlow { get; set; }
    public string? RegistrationFlow { get; set; }
    public string? DirectGrantFlow { get; set; }
    public string? ResetCredentialsFlow { get; set; }
    public string? ClientAuthenticationFlow { get; set; }
    public string? DockerAuthenticationFlow { get; set; }
    public Dictionary<string, string>? Attributes { get; set; }
    public string? KeycloakVersion { get; set; }
    public bool? UserManagedAccessAllowed { get; set; }
    public bool? Social { get; set; }
    public bool? UpdateProfileOnInitialSocialLogin { get; set; }
    public Dictionary<string, string>? SocialProviders { get; set; }
    public Dictionary<string, List<object>>? ApplicationScopeMappings { get; set; }
    public List<ApplicationRepresentation>? Applications { get; set; }
    public List<OAuthClientRepresentation>? OauthClients { get; set; }
    public List<ClientTemplateRepresentation>? ClientTemplates { get; set; }
}
