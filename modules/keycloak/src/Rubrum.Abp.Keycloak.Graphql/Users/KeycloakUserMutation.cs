﻿using HotChocolate;
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
    [UseMutationConvention]
    [UseAbpError]
    public async Task<KeycloakUserDto> ChangePasswordAsync(
        [ID("KeycloakUser")] string id,
        string password,
        [Service] IKeycloakUserGraphqlService service)
    {
        return await service.ChangePasswordAsync(id, new ChangePasswordKeycloakUserInput { Password = password });
    }

    [GraphQLName("changeRolesForUser")]
    [UseMutationConvention]
    [UseAbpError]
    public async Task<KeycloakUserDto> ChangeRolesAsync(
        [ID("KeycloakUser")] string id,
        string[] roleNames,
        [Service] IKeycloakUserGraphqlService service)
    {
        return await service.ChangeRolesAsync(id, new ChangeRolesKeycloakUserInput { RoleNames = roleNames });
    }
}
