using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Services.Contracts;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.Root;

public class CountryQueryType :
    ReadOnlyQueryType<CountryDto, Guid, ICountryGraphqlService, CountryFilterType, CountrySortType>
{
    protected override string TypeName => CountryConstants.TypeName;
    protected override string FieldNameGetById => "countryById";
    protected override string FieldNameGet => "country";
    protected override string FieldNameGetList => "countries";
    protected override string FieldNameAny => "countriesAny";
    protected override string FieldNameCount => "countriesCount";
}