using Rubrum.Abp.Keycloak.Mapper.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using static Rubrum.Abp.Keycloak.Permissions.KeycloakRolePermissions.Roles;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleAppService : ApplicationService, IKeycloakRoleAppService
{
    protected readonly IKeycloakClient KeycloakClient;
    protected readonly IKeycloakRoleMapper Mapper;

    public KeycloakRoleAppService(
        IKeycloakClient keycloakClient,
        IKeycloakRoleMapper mapper)
    {
        KeycloakClient = keycloakClient;
        Mapper = mapper;
    }
    
    public async Task<KeycloakRoleDto> GetAsync(string id)
    {
        await CheckPolicyAsync(Default);
        
        var role = await KeycloakClient.GetRoleByIdAsync(id);
        return Mapper.Map(role);
    }

    public async Task<PagedResultDto<KeycloakRoleDto>> GetListAsync(PagedResultRequestDto input)
    {
        await CheckPolicyAsync(Default);

        var roles = await KeycloakClient.GetRolesAsync();
        var totalCount = roles.Count;

        return new PagedResultDto<KeycloakRoleDto>(
            totalCount,
            roles.Skip(input.SkipCount).Take(input.MaxResultCount).Select(Mapper.Map).ToList());
    }

    public async Task<KeycloakRoleDto> CreateAsync(CreateKeycloakRoleInput input)
    {
        await CheckPolicyAsync(Create);

        var role = new RoleRepresentation { Name = input.Name };

        await KeycloakClient.CreateRoleAsync(role);

        role = await KeycloakClient.GetRoleByNameAsync(input.Name);

        return Mapper.Map(role);
    }

    public async Task<KeycloakRoleDto> UpdateAsync(string id, UpdateKeycloakRoleInput input)
    {
        await CheckPolicyAsync(Update);

        var role = await KeycloakClient.GetRoleByIdAsync(id);

        role.Name = input.Name;

        await KeycloakClient.UpdateRoleByIdAsync(id, role);
        
        return Mapper.Map(role);
    }

    public async Task DeleteAsync(string id)
    {
        await CheckPolicyAsync(Delete);

        await KeycloakClient.DeleteRoleByIdAsync(id);
    }
}
