using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Keycloak.Roles;

namespace Rubrum.Abp.Keycloak.Users;

[ExtendObjectType(OperationType.Query)]
public class KeycloakUserQuery : IGraphqlType
{
    [GraphQLName("keycloakRolesByUserId")]
    [Authorize]
    public async Task<IReadOnlyList<KeycloakRoleDto>> GetRolesAsync(
        [ID(KeycloakUserConstants.TypeName)] string id,
        [Service] IKeycloakUserGraphqlService service)
    {
        var roles = await service.GetRolesAsync(id);
        return roles.Items;
    }
}
