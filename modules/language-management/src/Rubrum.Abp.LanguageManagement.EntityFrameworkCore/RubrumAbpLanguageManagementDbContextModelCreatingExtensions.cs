using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using static Rubrum.Abp.Data.RubrumAbpCommonDbProperties;
using static Rubrum.Abp.LanguageManagement.LanguageConstants;

namespace Rubrum.Abp.LanguageManagement.EntityFrameworkCore;

public static class RubrumAbpLanguageManagementDbContextModelCreatingExtensions
{
    public static void ConfigureLanguageManagement(this ModelBuilder builder)
    {
        builder.Entity<Language>(b =>
        {
            b.ToTable(DbTablePrefix + "Languages", DbSchema);

            b.ConfigureByConvention();

            b.HasIndex(x => x.Name);

            b.Property(x => x.Name)
                .HasMaxLength(MaxNameLenght)
                .IsRequired();

            b.ApplyObjectExtensionMappings();
        });

        builder.TryConfigureObjectExtensions<LanguageManagementDbContext>();
    }
}
