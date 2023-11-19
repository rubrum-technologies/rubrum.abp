using Rubrum.Abp.Graphql.Services;

namespace Rubrum.Abp.Keycloak.Users;

public interface IKeycloakUserGraphqlService :
    IKeycloakUserAppService,
    ICrudGraphqlService<KeycloakUserDto, string, CreateKeycloakUserInput, UpdateKeycloakUserInput>
{
}
