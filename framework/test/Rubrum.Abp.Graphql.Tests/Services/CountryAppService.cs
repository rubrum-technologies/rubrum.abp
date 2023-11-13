using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Domain;
using Rubrum.Abp.Graphql.Services.Contracts;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public class CountryAppService :
    CrudAppService<Country, CountryDto, Guid, PagedAndSortedResultRequestDto, CreateCountryInput, UpdateCountryInput>,
    ICountryAppService
{
    public CountryAppService(IRepository<Country, Guid> repository) : base(repository)
    {
    }

    protected override CountryDto MapToGetOutputDto(Country entity)
    {
        return new CountryDto { Id = entity.Id, Name = entity.Name };
    }

    protected override CountryDto MapToGetListOutputDto(Country entity)
    {
        return new CountryDto { Id = entity.Id, Name = entity.Name };
    }

    protected override Country MapToEntity(CreateCountryInput createInput)
    {
        return new Country(GuidGenerator.Create(), createInput.Name);
    }

    protected override void MapToEntity(UpdateCountryInput updateInput, Country entity)
    {
        entity.Name = updateInput.Name;
    }
}
