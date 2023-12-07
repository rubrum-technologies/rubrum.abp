using GreenDonut;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;

namespace Rubrum.Abp.ImageStoring;

public class ImagesByTagDataLoader :
    GroupedDataLoader<string, ImageInformationDto>,
    IImagesByTagDataLoader,
    IScopedDependency
{
    private readonly IImageInformationRepository _imageRepository;
    private readonly IAsyncQueryableExecuter _asyncExecuter;

    public ImagesByTagDataLoader(
        IBatchScheduler batchScheduler,
        IImageInformationRepository imageRepository,
        IAsyncQueryableExecuter asyncExecuter,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _imageRepository = imageRepository;
        _asyncExecuter = asyncExecuter;
    }

    protected override async Task<ILookup<string, ImageInformationDto>> LoadGroupedBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        var query = (await _imageRepository.GetQueryableAsync())
            .Where(x => keys.Contains(x.Tag))
            .Select(x => new ImageInformationDto { Id = x.Id, Tag = x.Tag });

        var result = await _asyncExecuter.ToListAsync(query, cancellationToken);

        return result.ToLookup(x => x.Tag!, x => x);
    }
}
