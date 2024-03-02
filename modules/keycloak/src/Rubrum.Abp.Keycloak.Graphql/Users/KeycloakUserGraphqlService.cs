using Rubrum.Abp.Keycloak.Mapper.Interfaces;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserGraphqlService(
    IKeycloakClient keycloakClient,
    IKeycloakUserMapper userMapper,
    IKeycloakRoleMapper roleMapper)
    : KeycloakUserAppService(keycloakClient, userMapper, roleMapper), IKeycloakUserGraphqlService
{
    public async Task<IQueryable<KeycloakUserDto>> GetQueryableAsync()
    {
        return (await KeycloakClient.GetUsersAsync()).Select(UserMapper.Map).AsQueryable();
    }
}
