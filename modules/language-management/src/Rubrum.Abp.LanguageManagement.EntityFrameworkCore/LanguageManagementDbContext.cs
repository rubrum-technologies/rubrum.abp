using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static Rubrum.Abp.LanguageManagement.RubrumAbpLanguageManagementDbProperties;

namespace Rubrum.Abp.LanguageManagement.EntityFrameworkCore;

[ConnectionStringName(ConnectionStringName)]
public class LanguageManagementDbContext : AbpDbContext<LanguageManagementDbContext>, ILanguageManagementDbContext
{
    public LanguageManagementDbContext(DbContextOptions<LanguageManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<SystemLanguage> Languages => Set<SystemLanguage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureLanguageManagement();
    }
}
