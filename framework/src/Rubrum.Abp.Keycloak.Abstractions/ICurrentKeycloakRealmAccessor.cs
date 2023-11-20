namespace Rubrum.Abp.Keycloak;

public interface ICurrentKeycloakRealmAccessor
{
    BasicKeycloakRealmInfo? Current { get; set; }
}
