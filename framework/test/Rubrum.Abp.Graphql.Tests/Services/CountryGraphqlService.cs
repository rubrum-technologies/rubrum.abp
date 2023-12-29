using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Domain;
using Rubrum.Abp.Graphql.Services.Contracts;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public class CountryGraphqlService : CountryAppService, ICountryGraphqlService
{
    public CountryGraphqlService(IRepository<Country, Guid> repository)
        : base(repository)
    {
    }

    public async Task<IQueryable<CountryDto>> GetQueryableAsync()
    {
        return (await Repository.GetQueryableAsync()).Select(x => new CountryDto { Id = x.Id, Name = x.Name });
    }
}
