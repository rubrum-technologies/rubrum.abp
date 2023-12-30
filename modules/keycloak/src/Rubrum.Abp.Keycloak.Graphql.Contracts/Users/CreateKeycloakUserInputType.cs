using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Keycloak.Users;

public class CreateKeycloakUserInputType : InputObjectType<CreateKeycloakUserInput>, IGraphqlType;
