using HotChocolate.Language;
using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.MultilingualObjects.Models;

[ExtendObjectType(OperationType.Query)]
public class Query : IGraphqlType
{
    public Country GetCountry()
    {
        var country = new Country("Россия");

        country.ChangeTranslation(new CountryTranslation("en", "Russian"));

        return country;
    }
}
