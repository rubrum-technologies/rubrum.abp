using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Keycloak.Roles;

public class UpdateKeycloakRoleInputType : InputObjectType<UpdateKeycloakRoleInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateKeycloakRoleInput> descriptor)
    {
        descriptor.UpdateEntity<UpdateKeycloakRoleInput, StringType>("KeycloakRole");
    }
}
