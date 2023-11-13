using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Domain;
using Rubrum.Abp.Graphql.Services.Contracts;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public class CityAppService :
    CrudAppService<City, CityDto, int, PagedAndSortedResultRequestDto, CreateCityInput, UpdateCityInput>,
    ICityAppService
{
    public CityAppService(IRepository<City, int> repository) : base(repository)
    {
    }

    protected override CityDto MapToGetOutputDto(City entity)
    {
        return new CityDto { Id = entity.Id, CountryId = entity.CountryId, Name = entity.Name };
    }

    protected override CityDto MapToGetListOutputDto(City entity)
    {
        return new CityDto { Id = entity.Id, CountryId = entity.CountryId, Name = entity.Name };
    }

    protected override City MapToEntity(CreateCityInput createInput)
    {
        return new City(Random.Shared.Next(), createInput.CountryId, createInput.Name);
    }

    protected override void MapToEntity(UpdateCityInput updateInput, City entity)
    {
        entity.CountryId = updateInput.CountryId;
        entity.Name = updateInput.Name;
    }
}
