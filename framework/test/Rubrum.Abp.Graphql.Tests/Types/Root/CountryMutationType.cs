using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Services.Contracts;

namespace Rubrum.Abp.Graphql.Types.Root;

public class CountryMutationType :
    EntityMutationType<CountryDto, Guid, ICountryGraphqlService, CreateCountryInput, UpdateCountryInput>
{
    protected override string TypeName => CountryConstants.TypeName;

    protected override string TypeNameSingular => "Country";

    protected override string TypeNameInPlural => "Countries";
}
