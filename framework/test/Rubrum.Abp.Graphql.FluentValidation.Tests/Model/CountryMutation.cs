using HotChocolate.Language;
using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Validation;

namespace Rubrum.Abp.Graphql.Model;

[ExtendObjectType(OperationType.Mutation)]
public class CountryMutation : IGraphqlType
{
    [UseAbpError]
    [UseMutationConvention]
    public Country CreateCountry(CreateCountryInput input)
    {
        return new Country { Name = input.Name };
    }
}
