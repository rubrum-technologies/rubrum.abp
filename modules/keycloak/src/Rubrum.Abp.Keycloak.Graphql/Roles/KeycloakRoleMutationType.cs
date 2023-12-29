using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleMutationType :
    EntityMutationType<KeycloakRoleDto, string, IKeycloakRoleGraphqlService, CreateKeycloakRoleInput,
        UpdateKeycloakRoleInput>
{
    protected override string TypeName => "KeycloakRole";

    protected override string TypeNameSingular => "KeycloakRole";

    protected override string TypeNameInPlural => "KeycloakRoles";
}
