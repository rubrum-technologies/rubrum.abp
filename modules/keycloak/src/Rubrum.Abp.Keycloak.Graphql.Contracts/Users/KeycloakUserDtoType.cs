using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserDtoType : ObjectType<KeycloakUserDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<KeycloakUserDto> descriptor)
    {
        descriptor.Entity<KeycloakUserDto, string>();
    }
}
