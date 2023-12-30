using Microsoft.EntityFrameworkCore;
using Rubrum.Abp.Graphql.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Rubrum.Abp.Graphql.EntityFrameworkCore;

[ReplaceDbContext(typeof(ITenantManagementDbContext))]
public class GraphqlTestDbContext(DbContextOptions<GraphqlTestDbContext> options)
    : AbpDbContext<GraphqlTestDbContext>(options), ITenantManagementDbContext
{
    public DbSet<Country> Countries => Set<Country>();

    public DbSet<City> Cities => Set<City>();

    public DbSet<Tenant> Tenants => Set<Tenant>();

    public DbSet<TenantConnectionString> TenantConnectionStrings => Set<TenantConnectionString>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureTenantManagement();
    }
}
