using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleMutationType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityMutation<KeycloakRoleDto, string, IKeycloakRoleGraphqlService, CreateKeycloakRoleInput,
            UpdateKeycloakRoleInput>(KeycloakRoleConstants.TypeName, "KeycloakRole");
    }
}
