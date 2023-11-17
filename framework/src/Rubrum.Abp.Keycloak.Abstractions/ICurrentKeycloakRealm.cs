namespace Rubrum.Abp.Keycloak;

public interface ICurrentKeycloakRealm
{
    string RealmName { get; }

    IDisposable Change(string realmName);
}
