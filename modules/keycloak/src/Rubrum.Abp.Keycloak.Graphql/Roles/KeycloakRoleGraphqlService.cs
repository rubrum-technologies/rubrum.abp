using Rubrum.Abp.Keycloak.Mapper.Interfaces;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleGraphqlService : KeycloakRoleAppService, IKeycloakRoleGraphqlService
{
    public KeycloakRoleGraphqlService(
        IKeycloakClient keycloakClient,
        IKeycloakRoleMapper mapper)
        : base(keycloakClient, mapper)
    {
    }

    public async Task<IQueryable<KeycloakRoleDto>> GetQueryableAsync()
    {
        return (await KeycloakClient.GetRolesAsync()).Select(Mapper.Map).AsQueryable();
    }
}
