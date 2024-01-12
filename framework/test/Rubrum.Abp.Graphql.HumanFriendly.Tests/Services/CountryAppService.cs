using Rubrum.Abp.Graphql.HumanFriendly.Application;
using Rubrum.Abp.Graphql.HumanFriendly.Domain;
using Rubrum.Abp.Graphql.HumanFriendly.Services.Contracts;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.HumanFriendly.Services;

public class CountryAppService(IReadOnlyRepository<Country, Guid> repository) :
    ReadOnlyAppService<Country, CountryDto, Guid, PagedAndSortedResultRequestDto>(repository),
    ICountryAppService
{
    public async Task<CountryDto> GetByHumanIdAsync(long id)
    {
        var entity = await Repository.FirstAsync(x => x.HumanFriendlyId == id);

        return await MapToGetOutputDtoAsync(entity);
    }

    protected override CountryDto MapToGetOutputDto(Country entity)
    {
        return new CountryDto { Id = entity.Id, Name = entity.Name, HumanFriendlyId = entity.HumanFriendlyId };
    }

    protected override CountryDto MapToGetListOutputDto(Country entity)
    {
        return new CountryDto { Id = entity.Id, Name = entity.Name, HumanFriendlyId = entity.HumanFriendlyId };
    }
}
