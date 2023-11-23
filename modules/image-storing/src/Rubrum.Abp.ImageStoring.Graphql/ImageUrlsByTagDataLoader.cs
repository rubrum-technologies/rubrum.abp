using GreenDonut;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;

namespace Rubrum.Abp.ImageStoring;

public class ImageUrlsByTagDataLoader : GroupedDataLoader<string, string>,
    IImageUrlsByTagDataLoader,
    IScopedDependency
{
    private readonly IAsyncQueryableExecuter _asyncExecuter;
    private readonly IImageInformationRepository _repository;
    private readonly RubrumAbpImageStoringOptions _imageStoringOptions;

    public ImageUrlsByTagDataLoader(
        IBatchScheduler batchScheduler,
        IAsyncQueryableExecuter asyncExecuter,
        IImageInformationRepository repository,
        IOptions<RubrumAbpImageStoringOptions> imageStoringOptions,
        DataLoaderOptions? options = null) : base(batchScheduler,
        options)
    {
        _asyncExecuter = asyncExecuter;
        _repository = repository;
        _imageStoringOptions = imageStoringOptions.Value;
    }

    protected override async Task<ILookup<string, string>> LoadGroupedBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        var prefixUrl = _imageStoringOptions.PrefixUrl.TrimStart('/').TrimEnd('/');
        var query = (await _repository.GetQueryableAsync())
            .Where(x => keys.Contains(x.Tag))
            .Select(x => new { x.Id, x.Tag });

        var ids = await _asyncExecuter.ToListAsync(query, cancellationToken);
        var urls = ids.Select(x => new { x.Tag, Url = $"/{prefixUrl}/{x.Id}" });

        return urls.ToLookup(x => x.Tag, x => x.Url)!;
    }
}
