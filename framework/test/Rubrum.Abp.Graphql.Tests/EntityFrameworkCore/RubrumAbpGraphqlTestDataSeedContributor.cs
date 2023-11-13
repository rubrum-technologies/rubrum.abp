using Rubrum.Abp.Graphql.Domain;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static Rubrum.Abp.Graphql.RubrumAbpGraphqlTestConstants;

namespace Rubrum.Abp.Graphql.EntityFrameworkCore;

public class RubrumAbpGraphqlTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Country, Guid> _countryRepository;

    public RubrumAbpGraphqlTestDataSeedContributor(IRepository<Country, Guid> countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _countryRepository.InsertAsync(new Country(CountryId, "Russian"));
    }
}
