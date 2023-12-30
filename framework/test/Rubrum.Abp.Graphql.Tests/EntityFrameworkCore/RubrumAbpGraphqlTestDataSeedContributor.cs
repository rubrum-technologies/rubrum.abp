using Rubrum.Abp.Graphql.Domain;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static Rubrum.Abp.Graphql.RubrumAbpGraphqlTestConstants;

namespace Rubrum.Abp.Graphql.EntityFrameworkCore;

public class RubrumAbpGraphqlTestDataSeedContributor(IBasicRepository<Country> countryRepository)
    : IDataSeedContributor, ITransientDependency
{
    public async Task SeedAsync(DataSeedContext context)
    {
        await countryRepository.InsertAsync(new Country(CountryId, "Russian"));
    }
}
