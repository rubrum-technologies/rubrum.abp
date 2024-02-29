using GreenDonut;
using Rubrum.Abp.ImageStoring.Mapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;
using Volo.Abp.Uow;

namespace Rubrum.Abp.ImageStoring;

public class ImagesByTagDataLoader(
    IBatchScheduler batchScheduler,
    IUnitOfWorkManager unitOfWorkManager,
    IImageInformationRepository imageRepository,
    IAsyncQueryableExecuter asyncExecuter,
    IImageInformationMapper mapper,
    DataLoaderOptions? options = null)
    : GroupedDataLoader<string, ImageInformationDto>(batchScheduler, options), IImagesByTagDataLoader, IScopedDependency
{
    protected override async Task<ILookup<string, ImageInformationDto>> LoadGroupedBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        using var uow = unitOfWorkManager.Begin(true);

        var query = (await imageRepository.GetQueryableAsync())
            .Where(x => keys.Contains(x.Tag));

        var result = await asyncExecuter.ToListAsync(query, cancellationToken);

        return result.Select(mapper.Map).ToLookup(x => x.Tag!, x => x);
    }
}
