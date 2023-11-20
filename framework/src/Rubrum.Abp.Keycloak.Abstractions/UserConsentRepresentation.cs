namespace Rubrum.Abp.Keycloak;

public class UserConsentRepresentation
{
    public string? ClientId { get; set; }
    public List<string>? GrantedClientScopes { get; set; }
    public long? CreatedDate { get; set; }
    public long? LastUpdatedDate { get; set; }
    public List<string>? GrantedRealmRoles { get; set; }
}
