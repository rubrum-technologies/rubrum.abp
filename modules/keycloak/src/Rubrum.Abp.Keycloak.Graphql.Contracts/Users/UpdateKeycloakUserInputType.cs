using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Users;

public class UpdateKeycloakUserInputType : InputObjectType<UpdateKeycloakUserInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateKeycloakUserInput> descriptor)
    {
        descriptor.AddFieldKey<UpdateKeycloakUserInput, StringType>("KeycloakUser");
    }
}
