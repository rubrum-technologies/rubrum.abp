using Rubrum.Abp.Graphql.HumanFriendly.Application;
using Rubrum.Abp.Graphql.HumanFriendly.Domain;
using Rubrum.Abp.Graphql.HumanFriendly.Services.Contracts;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.HumanFriendly.Services;

public class CountryGraphqlService(IReadOnlyRepository<Country, Guid> repository)
    : CountryAppService(repository), ICountryGraphqlService
{
    public async Task<IQueryable<CountryDto>> GetQueryableAsync()
    {
        return (await Repository.GetQueryableAsync()).Select(x => new CountryDto { Id = x.Id, Name = x.Name });
    }
}
