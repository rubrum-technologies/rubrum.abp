using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Services.Contracts;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.Root;

public class CityMutationType : CudMutationType<CityDto, int, ICityGraphqlService, CreateCityInput, UpdateCityInput>
{
    protected override string TypeName => "City";
    protected override string FieldNameCreate => "createCity";
    protected override string FieldNameUpdate => "updateCity";
    protected override string FieldNameDelete => "deleteCity";
}