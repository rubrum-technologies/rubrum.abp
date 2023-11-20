using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.Keycloak.Roles;

public interface IKeycloakRoleAppService :
    ICrudAppService<KeycloakRoleDto, string, PagedResultRequestDto, CreateKeycloakRoleInput, UpdateKeycloakRoleInput>
{
}
