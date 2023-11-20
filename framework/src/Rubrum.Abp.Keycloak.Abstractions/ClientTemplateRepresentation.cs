namespace Rubrum.Abp.Keycloak;

public class ClientTemplateRepresentation
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Protocol { get; set; }
    public bool? FullScopeAllowed { get; set; }
    public bool? BearerOnly { get; set; }
    public bool? ConsentRequired { get; set; }
    public bool? StandardFlowEnabled { get; set; }
    public bool? ImplicitFlowEnabled { get; set; }
    public bool? DirectAccessGrantsEnabled { get; set; }
    public bool? ServiceAccountsEnabled { get; set; }
    public bool? PublicClient { get; set; }
    public bool? FrontchannelLogout { get; set; }
    public Dictionary<string, string>? Attributes { get; set; }
    public List<ProtocolMapperRepresentation>? ProtocolMappers { get; set; }
}
