using Microsoft.EntityFrameworkCore;
using Rubrum.Abp.Graphql.Domain;
using Volo.Abp.EntityFrameworkCore;

namespace Rubrum.Abp.Graphql.EntityFrameworkCore;

public class GraphqlTestDbContext : AbpDbContext<GraphqlTestDbContext>
{
    public GraphqlTestDbContext(DbContextOptions<GraphqlTestDbContext> options)
        : base(options)
    {
    }

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<City> Cities => Set<City>();
}
