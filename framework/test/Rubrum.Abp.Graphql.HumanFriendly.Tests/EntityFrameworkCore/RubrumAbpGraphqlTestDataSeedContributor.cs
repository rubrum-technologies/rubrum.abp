using Rubrum.Abp.Graphql.HumanFriendly.Domain;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static Rubrum.Abp.Graphql.HumanFriendly.RubrumAbpGraphqlHumanFriendlyTestConstants;

namespace Rubrum.Abp.Graphql.HumanFriendly.EntityFrameworkCore;

public class RubrumAbpGraphqlTestDataSeedContributor(IBasicRepository<Country> countryRepository)
    : IDataSeedContributor, ITransientDependency
{
    public async Task SeedAsync(DataSeedContext context)
    {
        await countryRepository.InsertAsync(new Country(CountryId, "Russian"));
    }
}
