using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Validation;

namespace Rubrum.Abp.Keycloak.Users;

[ExtendObjectType(OperationType.Mutation)]
public class KeycloakUserMutation : IGraphqlType
{
    [GraphQLName("changePassword")]
    [Authorize]
    [UseMutationConvention]
    [UseAbpError]
    public async Task<KeycloakUserDto> ChangePasswordAsync(
        [ID(KeycloakUserConstants.TypeName)] string id,
        string password,
        [Service] IKeycloakUserGraphqlService service)
    {
        return await service.ChangePasswordAsync(id, new ChangePasswordKeycloakUserInput { Password = password });
    }

    [GraphQLName("changeRolesForUser")]
    [Authorize]
    [UseMutationConvention]
    [UseAbpError]
    public async Task<KeycloakUserDto> ChangeRolesAsync(
        [ID(KeycloakUserConstants.TypeName)] string id,
        string[] roleNames,
        [Service] IKeycloakUserGraphqlService service)
    {
        return await service.ChangeRolesAsync(id, new ChangeRolesKeycloakUserInput { RoleNames = roleNames });
    }
}
