using Rubrum.Abp.Keycloak.Mapper.Interfaces;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleGraphqlService(
    IKeycloakClient keycloakClient,
    IKeycloakRoleMapper mapper)
    : KeycloakRoleAppService(keycloakClient, mapper), IKeycloakRoleGraphqlService
{
    public async Task<IQueryable<KeycloakRoleDto>> GetQueryableAsync()
    {
        return (await KeycloakClient.GetRolesAsync()).Select(Mapper.Map).AsQueryable();
    }
}
