using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserMutationType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityMutation<KeycloakUserDto, string, IKeycloakUserGraphqlService, CreateKeycloakUserInput,
            UpdateKeycloakUserInput>(new EntityMutationOptions
        {
            TypeName = KeycloakUserConstants.TypeName,
            TypeNameSingular = "KeycloakUser",
            IsAuthorize = true
        });
    }
}
