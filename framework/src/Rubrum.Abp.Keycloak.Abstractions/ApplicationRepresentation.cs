namespace Rubrum.Abp.Keycloak;

public class ApplicationRepresentation
{
    public string? Id { get; set; }
    public string? ClientId { get; set; }
    public string? Description { get; set; }
    public string? RootUrl { get; set; }
    public string? AdminUrl { get; set; }
    public string? BaseUrl { get; set; }
    public bool? SurrogateAuthRequired { get; set; }
    public bool? Enabled { get; set; }
    public bool? AlwaysDisplayInConsole { get; set; }
    public string? ClientAuthenticatorType { get; set; }
    public string? Secret { get; set; }
    public string? RegistrationAccessToken { get; set; }
    public List<string>? DefaultRoles { get; set; }
    public List<string>? RedirectUris { get; set; }
    public List<string>? WebOrigins { get; set; }
    public int? NotBefore { get; set; }
    public bool? BearerOnly { get; set; }
    public bool? ConsentRequired { get; set; }
    public bool? StandardFlowEnabled { get; set; }
    public bool? ImplicitFlowEnabled { get; set; }
    public bool? DirectAccessGrantsEnabled { get; set; }
    public bool? ServiceAccountsEnabled { get; set; }
    public bool? Oauth2DeviceAuthorizationGrantEnabled { get; set; }
    public bool? AuthorizationServicesEnabled { get; set; }
    public bool? DirectGrantsOnly { get; set; }
    public bool? PublicClient { get; set; }
    public bool? FrontchannelLogout { get; set; }
    public string? Protocol { get; set; }
    public Dictionary<string, string>? Attributes { get; set; }
    public Dictionary<string, string>? AuthenticationFlowBindingOverrides { get; set; }
    public bool? FullScopeAllowed { get; set; }
    public int? NodeReRegistrationTimeout { get; set; }
    public Dictionary<string, int>? RegisteredNodes { get; set; }
    public List<ProtocolMapperRepresentation>? ProtocolMappers { get; set; }
    public string? ClientTemplate { get; set; }
    public bool? UseTemplateConfig { get; set; }
    public bool? UseTemplateScope { get; set; }
    public bool? UseTemplateMappers { get; set; }
    public List<string>? DefaultClientScopes { get; set; }
    public List<string>? OptionalClientScopes { get; set; }
    public ResourceServerRepresentation? AuthorizationSettings { get; set; }
    public Dictionary<string, bool>? Access { get; set; }
    public string? Origin { get; set; }
    public string? Name { get; set; }
    public ApplicationRepresentationClaims? Claims { get; set; }
}
