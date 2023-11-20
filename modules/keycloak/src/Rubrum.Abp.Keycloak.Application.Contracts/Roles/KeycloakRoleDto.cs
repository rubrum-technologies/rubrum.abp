using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleDto : EntityDto<string>
{
    public required string Name { get; init; }
}
