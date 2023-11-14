using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static Rubrum.Abp.ImageStoring.RubrumAbpImageStoringDbProperties;

namespace Rubrum.Abp.ImageStoring.EntityFrameworkCore;

[ConnectionStringName(ConnectionStringName)]
public class ImageStoringDbContext : AbpDbContext<ImageStoringDbContext>, IImageStoringDbContext
{
    public ImageStoringDbContext(DbContextOptions<ImageStoringDbContext> options) : base(options)
    {
    }

    public DbSet<ImageInformation> Images => Set<ImageInformation>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureImageStoring();
    }
}
