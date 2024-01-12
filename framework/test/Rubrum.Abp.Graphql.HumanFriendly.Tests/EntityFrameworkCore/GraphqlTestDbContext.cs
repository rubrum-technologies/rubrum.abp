using Microsoft.EntityFrameworkCore;
using Rubrum.Abp.EntityFrameworkCore.HumanFriendly;
using Rubrum.Abp.Graphql.HumanFriendly.Domain;
using Volo.Abp.EntityFrameworkCore;

namespace Rubrum.Abp.Graphql.HumanFriendly.EntityFrameworkCore;

public class GraphqlTestDbContext(DbContextOptions<GraphqlTestDbContext> options)
    : AbpDbContext<GraphqlTestDbContext>(options)
{
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>(b =>
        {
            b.HasKey(x => x.HumanFriendlyId);
            b.ConfigureByHumanFriendlyId();
        });
    }
}
