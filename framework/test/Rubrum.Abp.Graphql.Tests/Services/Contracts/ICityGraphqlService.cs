using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;

namespace Rubrum.Abp.Graphql.Services.Contracts;

public interface ICityGraphqlService : ICrudGraphqlService<CityDto, int, CreateCityInput, UpdateCityInput>
{
    
}