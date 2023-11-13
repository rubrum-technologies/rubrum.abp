using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rubrum.Abp.LanguageManagement.EntityFrameworkCore;

public class LanguageManagementDbContext : AbpDbContext<LanguageManagementDbContext>, ILanguageManagementDbContext
{
    public LanguageManagementDbContext(DbContextOptions<LanguageManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Language> Languages => Set<Language>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureLanguageManagement();
    }
}
