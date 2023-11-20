using Mapster;
using Rubrum.Abp.Keycloak.Roles;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Keycloak.Mapper.Interfaces;

[Mapper]
public interface IKeycloakRoleMapper : ITransientDependency
{
    KeycloakRoleDto Map(RoleRepresentation role);
}
