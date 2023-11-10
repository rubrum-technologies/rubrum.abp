using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Services.Contracts;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.Root;

public class CityQueryType : ReadOnlyQueryType<CityDto, int, ICityGraphqlService, CityFilterType, CitySortType>
{
    protected override string TypeName => "City";
    protected override string FieldNameGetById => "cityById";
    protected override string FieldNameGet => "city";
    protected override string FieldNameGetList => "cities";
    protected override string FieldNameAny => "citiesAny";
    protected override string FieldNameCount => "citiesCount";
}