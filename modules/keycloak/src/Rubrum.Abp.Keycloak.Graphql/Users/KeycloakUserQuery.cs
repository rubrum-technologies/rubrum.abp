﻿using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Keycloak.Roles;

namespace Rubrum.Abp.Keycloak.Users;

[ExtendObjectType(OperationType.Query)]
public class KeycloakUserQuery : IGraphqlType
{
    [GraphQLName("keycloakRolesByUserId")]
    public async Task<IReadOnlyList<KeycloakRoleDto>> GetRolesAsync(
        string id,
        [Service] IKeycloakUserGraphqlService service)
    {
        var roles = await service.GetRolesAsync(id);
        return roles.Items;
    }
}
