using Rubrum.Abp.Keycloak.Mapper.Interfaces;
using Rubrum.Abp.Keycloak.Roles;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using static Rubrum.Abp.Keycloak.Permissions.KeycloakUserPermissions.Users;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserAppService : ApplicationService, IKeycloakUserAppService
{
    protected readonly IKeycloakClient KeycloakClient;
    protected readonly IKeycloakRoleMapper RoleMapper;
    protected readonly IKeycloakUserMapper UserMapper;

    public KeycloakUserAppService(
        IKeycloakClient keycloakClient,
        IKeycloakUserMapper userMapper,
        IKeycloakRoleMapper roleMapper)
    {
        KeycloakClient = keycloakClient;
        UserMapper = userMapper;
        RoleMapper = roleMapper;
    }

    public async Task<KeycloakUserDto> GetAsync(string id)
    {
        await CheckPolicyAsync(Default);

        var user = await KeycloakClient.GetUserByIdAsync(id);
        return UserMapper.Map(user);
    }

    public async Task<PagedResultDto<KeycloakUserDto>> GetListAsync(PagedResultRequestDto input)
    {
        await CheckPolicyAsync(Default);

        var users = await KeycloakClient.GetUsersAsync(first: input.SkipCount, max: input.MaxResultCount);
        var totalCount = await KeycloakClient.GetUsersCountAsync();

        return new PagedResultDto<KeycloakUserDto>(totalCount, users.Select(UserMapper.Map).ToList());
    }

    public async Task<KeycloakUserDto> CreateAsync(CreateKeycloakUserInput input)
    {
        await CheckPolicyAsync(Create);

        var user = new UserRepresentation
        {
            Username = input.UserName,
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
            RealmRoles = input.RoleNames?.ToList(),
            Enabled = input.IsActive
        };

        await KeycloakClient.CreateUserAsync(user);

        user = (await KeycloakClient.GetUsersAsync(username: input.UserName)).First();

        return UserMapper.Map(user);
    }

    public async Task<KeycloakUserDto> UpdateAsync(string id, UpdateKeycloakUserInput input)
    {
        await CheckPolicyAsync(Update);

        var user = await KeycloakClient.GetUserByIdAsync(id);

        user.Username = input.UserName;
        user.FirstName = input.FirstName;
        user.LastName = input.LastName;
        user.Email = input.Email;
        user.Enabled = input.IsActive;

        await KeycloakClient.UpdateUserAsync(id, user);

        return await GetAsync(id);
    }

    public async Task DeleteAsync(string id)
    {
        await CheckPolicyAsync(Delete);

        await KeycloakClient.DeleteUserByIdAsync(id);
    }

    public async Task<ListResultDto<KeycloakRoleDto>> GetRolesAsync(string id)
    {
        await CheckPolicyAsync(Default);

        var mappings = await KeycloakClient.GetUserRoleMappingsAsync(id);
        var roles = mappings.RealmMappings ?? new List<RoleRepresentation>();

        return new ListResultDto<KeycloakRoleDto>(roles.Select(RoleMapper.Map).ToList());
    }

    public async Task<KeycloakUserDto> ChangePasswordAsync(string id, ChangePasswordKeycloakUserInput input)
    {
        await CheckPolicyAsync(ChangePassword);

        var user = await KeycloakClient.GetUserByIdAsync(id);

        await KeycloakClient.ResetPasswordAsync(
            id,
            new CredentialRepresentation { Type = "password", Temporary = false, Value = input.Password });

        return UserMapper.Map(user);
    }

    public async Task<KeycloakUserDto> ChangeRolesAsync(string id, ChangeRolesKeycloakUserInput input)
    {
        await CheckPolicyAsync(ChangeRoles);

        var roles = await KeycloakClient.GetRolesAsync();

        await KeycloakClient.ChangeUserRoleMappingsRealmAsync(
            id,
            roles.Where(x => input.RoleNames.Contains(x.Name)).ToList());

        return await GetAsync(id);
    }
}
