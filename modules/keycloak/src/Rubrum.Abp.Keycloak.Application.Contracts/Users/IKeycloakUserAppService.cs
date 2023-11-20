using Rubrum.Abp.Keycloak.Roles;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.Keycloak.Users;

public interface IKeycloakUserAppService : 
    ICrudAppService<KeycloakUserDto, string, PagedResultRequestDto, CreateKeycloakUserInput, UpdateKeycloakUserInput>
{
    Task<ListResultDto<KeycloakRoleDto>> GetRolesAsync(string id);
    Task<KeycloakUserDto> ChangePasswordAsync(string id, ChangePasswordKeycloakUserInput input);
    Task<KeycloakUserDto> ChangeRolesAsync(string id, ChangeRolesKeycloakUserInput input);
}
