namespace Rubrum.Abp.Keycloak;

public class ClientScopeRepresentation
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Protocol { get; set; }
    public Dictionary<string, string>? Attributes { get; set; }
    public List<ProtocolMapperRepresentation>? ProtocolMappers { get; set; }
}
