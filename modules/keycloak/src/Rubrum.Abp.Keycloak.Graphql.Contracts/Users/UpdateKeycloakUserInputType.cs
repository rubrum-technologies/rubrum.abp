using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Keycloak.Users;

public class UpdateKeycloakUserInputType : InputObjectType<UpdateKeycloakUserInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateKeycloakUserInput> descriptor)
    {
        descriptor.AddFieldKey<UpdateKeycloakUserInput, string>("KeycloakUser");
    }
}
