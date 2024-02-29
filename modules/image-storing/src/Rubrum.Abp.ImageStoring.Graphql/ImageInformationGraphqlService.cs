using Rubrum.Abp.ImageStoring.Mapper;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.ImageStoring;

public class ImageInformationGraphqlService(
    IImageInformationRepository repository,
    IImageInformationMapper mapper)
    : IImageInformationGraphqlService, ITransientDependency
{
    public async Task<IQueryable<ImageInformationDto>> GetQueryableAsync()
    {
        return (await repository.GetQueryableAsync()).Select(mapper.Projection);
    }
}
