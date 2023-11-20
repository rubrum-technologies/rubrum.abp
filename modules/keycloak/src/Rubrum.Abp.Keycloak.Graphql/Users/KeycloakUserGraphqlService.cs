using Rubrum.Abp.Keycloak.Mapper.Interfaces;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserGraphqlService : KeycloakUserAppService, IKeycloakUserGraphqlService
{
    public KeycloakUserGraphqlService(
        IKeycloakClient keycloakClient,
        IKeycloakUserMapper userMapper,
        IKeycloakRoleMapper roleMapper) : base(keycloakClient, userMapper, roleMapper)
    {
    }

    public async Task<IQueryable<KeycloakUserDto>> GetQueryableAsync()
    {
        return (await KeycloakClient.GetUsersAsync()).Select(UserMapper.Map).AsQueryable();
    }
}
