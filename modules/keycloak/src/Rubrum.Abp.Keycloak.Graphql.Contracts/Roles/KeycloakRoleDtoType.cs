using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Keycloak.Roles;

public class KeycloakRoleDtoType : ObjectType<KeycloakRoleDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<KeycloakRoleDto> descriptor)
    {
        descriptor.Entity<KeycloakRoleDto, string>();
    }
}
