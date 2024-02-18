using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserQueryType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityQuery<KeycloakUserDto, string>(new EntityQueryOptions
        {
            TypeName = KeycloakUserConstants.TypeName,
            TypeNameSingular = "KeycloakUser",
            TypeNameInPlural = "KeycloakUsers",
            IsAuthorize = true
        });
    }
}
