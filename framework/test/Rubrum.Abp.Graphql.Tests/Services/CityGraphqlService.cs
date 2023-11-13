using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Domain;
using Rubrum.Abp.Graphql.Services.Contracts;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public class CityGraphqlService : CityAppService, ICityGraphqlService
{
    public CityGraphqlService(IRepository<City, int> repository) : base(repository)
    {
    }

    public async Task<IQueryable<CityDto>> GetQueryableAsync()
    {
        return (await Repository.GetQueryableAsync()).Select(x =>
            new CityDto { Id = x.Id, CountryId = x.CountryId, Name = x.Name });
    }
}
