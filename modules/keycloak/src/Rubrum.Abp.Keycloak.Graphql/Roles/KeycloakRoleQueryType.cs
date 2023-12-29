using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleQueryType : EntityQueryType<KeycloakRoleDto, string, IKeycloakRoleGraphqlService>
{
    protected override string TypeName => "KeycloakRole";

    protected override string TypeNameSingular => "KeycloakRole";

    protected override string TypeNameInPlural => "KeycloakRoles";
}
