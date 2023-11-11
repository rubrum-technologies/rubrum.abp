using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Services.Contracts;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.Root;

public class CountryMutationType : 
    CudMutationType<CountryDto, Guid, ICountryGraphqlService, CreateCountryInput, UpdateCountryInput>
{
    protected override string TypeName => CountryConstants.TypeName;
    protected override string FieldNameCreate => "createCountry";
    protected override string FieldNameUpdate => "updateCountry";
    protected override string FieldNameDelete => "deleteCountry";
}