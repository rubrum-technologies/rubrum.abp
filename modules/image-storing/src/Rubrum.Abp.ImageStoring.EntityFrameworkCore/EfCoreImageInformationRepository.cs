using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rubrum.Abp.ImageStoring.EntityFrameworkCore;

#pragma warning disable CS8613

public class EfCoreImageInformationRepository(IDbContextProvider<IImageStoringDbContext> dbContextProvider)
    : EfCoreRepository<IImageStoringDbContext, ImageInformation, Guid>(dbContextProvider),
        IImageInformationRepository;
