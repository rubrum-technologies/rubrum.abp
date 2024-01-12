using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleQueryType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityQuery<KeycloakRoleDto, string>("KeycloakRole", "KeycloakRole", "KeycloakRoles");
    }
}
