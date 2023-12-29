using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserQueryType : EntityQueryType<KeycloakUserDto, string, IKeycloakUserGraphqlService>
{
    protected override string TypeName => "KeycloakUser";

    protected override string TypeNameSingular => "KeycloakUser";

    protected override string TypeNameInPlural => "KeycloakUsers";
}
