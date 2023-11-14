using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.ImageStoring;

public interface IImageInformationRepository : IRepository<ImageInformation, Guid>
{
}
