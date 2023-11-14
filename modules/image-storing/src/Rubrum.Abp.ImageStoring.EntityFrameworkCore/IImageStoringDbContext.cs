using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static Rubrum.Abp.ImageStoring.RubrumAbpImageStoringDbProperties;

namespace Rubrum.Abp.ImageStoring.EntityFrameworkCore;

[ConnectionStringName(ConnectionStringName)]
public interface IImageStoringDbContext : IAbpEfCoreDbContext
{
    DbSet<ImageInformation> Images { get; }
}
