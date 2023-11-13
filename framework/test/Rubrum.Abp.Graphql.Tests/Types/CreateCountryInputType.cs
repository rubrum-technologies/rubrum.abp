using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Inputs;

namespace Rubrum.Abp.Graphql.Types;

public class CreateCountryInputType : InputObjectType<CreateCountryInput>, IGraphqlType
{
}
