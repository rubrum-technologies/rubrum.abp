namespace Rubrum.Abp.Keycloak;

public class ClientProfilesRepresentation
{
    public List<ClientProfileRepresentation>? Profiles { get; set; }

    public List<ClientProfileRepresentation>? GlobalProfiles { get; set; }
}
