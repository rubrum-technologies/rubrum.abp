using HotChocolate.Language;
using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.Model;

[ExtendObjectType(OperationType.Query)]
public class CountryQuery : IGraphqlType
{
    public Country GetCountry()
    {
        return new Country { Name = "Test" };
    }
}