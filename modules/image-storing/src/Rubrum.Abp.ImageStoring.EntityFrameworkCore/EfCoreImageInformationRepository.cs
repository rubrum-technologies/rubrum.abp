using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rubrum.Abp.ImageStoring.EntityFrameworkCore;

public class EfCoreImageInformationRepository :
    EfCoreRepository<IImageStoringDbContext, ImageInformation, Guid>,
    IImageInformationRepository
{
    public EfCoreImageInformationRepository(IDbContextProvider<IImageStoringDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}
