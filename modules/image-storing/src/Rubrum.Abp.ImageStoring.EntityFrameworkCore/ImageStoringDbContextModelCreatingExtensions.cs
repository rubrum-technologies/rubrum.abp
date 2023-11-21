using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using static Rubrum.Abp.ImageStoring.RubrumAbpImageStoringDbProperties;

namespace Rubrum.Abp.ImageStoring.EntityFrameworkCore;

public static class ImageStoringDbContextModelCreatingExtensions
{
    public static void ConfigureImageStoring(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<ImageInformation>(b =>
        {
            b.ToTable(DbTablePrefix + "Images", DbSchema);

            b.ConfigureByConvention();

            b.Ignore(x => x.FileName);

            b.HasIndex(x => x.Tag);

            b.ApplyObjectExtensionMappings();
        });
        
        builder.TryConfigureObjectExtensions<ImageStoringDbContext>();
    }
}
