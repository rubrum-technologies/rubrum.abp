using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserMutationType : 
    EntityMutationType<KeycloakUserDto, string, IKeycloakUserGraphqlService, CreateKeycloakUserInput, UpdateKeycloakUserInput>
{
    protected override string TypeName => "KeycloakUser";
    protected override string TypeNameSingular => "KeycloakUser";
    protected override string TypeNameInPlural => "KeycloakUsers";
}
