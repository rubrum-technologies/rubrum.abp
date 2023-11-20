﻿using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Roles;

public class UpdateKeycloakRoleInputType : InputObjectType<UpdateKeycloakRoleInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateKeycloakRoleInput> descriptor)
    {
        descriptor.AddFieldKey<UpdateKeycloakRoleInput, StringType>("KeycloakRole");
    }
}