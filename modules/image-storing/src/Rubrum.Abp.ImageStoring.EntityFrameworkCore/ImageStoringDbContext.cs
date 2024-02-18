using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static Rubrum.Abp.ImageStoring.RubrumAbpImageStoringDbProperties;

namespace Rubrum.Abp.ImageStoring.EntityFrameworkCore;

[ConnectionStringName(ConnectionStringName)]
public class ImageStoringDbContext(DbContextOptions<ImageStoringDbContext> options)
    : AbpDbContext<ImageStoringDbContext>(options), IImageStoringDbContext
{
    public DbSet<ImageInformation> Images => Set<ImageInformation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureImageStoring();
    }
}
