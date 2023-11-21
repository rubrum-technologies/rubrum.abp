using Rubrum.Abp.Graphql.Services;

namespace Rubrum.Abp.Keycloak.Roles;

public interface IKeycloakRoleGraphqlService :
    IKeycloakRoleAppService,
    ICrudGraphqlService<KeycloakRoleDto, string, CreateKeycloakRoleInput, UpdateKeycloakRoleInput>
{
}
