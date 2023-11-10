using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Graphql.EntityFrameworkCore;

public class RubrumAbpGraphqlTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    public Task SeedAsync(DataSeedContext context)
    {
        return Task.CompletedTask;
    }
}