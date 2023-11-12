using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Services.Contracts;

namespace Rubrum.Abp.Graphql.Types.Root;

public class CityQueryType : EntityQueryType<CityDto, int, ICityGraphqlService>
{
    protected override string TypeName => "City";
    protected override string TypeNameSingular => "City";
    protected override string TypeNameInPlural => "Cities";
}