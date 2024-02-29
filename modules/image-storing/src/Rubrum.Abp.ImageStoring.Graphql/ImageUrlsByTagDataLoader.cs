using GreenDonut;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;
using Volo.Abp.Uow;

namespace Rubrum.Abp.ImageStoring;

public class ImageUrlsByTagDataLoader(
    IBatchScheduler batchScheduler,
    IUnitOfWorkManager unitOfWorkManager,
    IAsyncQueryableExecuter asyncExecuter,
    IImageInformationRepository repository,
    IOptions<RubrumAbpImageStoringOptions> imageStoringOptions,
    DataLoaderOptions? options = null)
    : GroupedDataLoader<string, string>(batchScheduler, options),
        IImageUrlsByTagDataLoader,
        IScopedDependency
{
    private readonly RubrumAbpImageStoringOptions _imageStoringOptions = imageStoringOptions.Value;

    protected override async Task<ILookup<string, string>> LoadGroupedBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        using var uow = unitOfWorkManager.Begin(true);

        var prefixUrl = _imageStoringOptions.PrefixUrl.TrimStart('/').TrimEnd('/');
        var query = (await repository.GetQueryableAsync())
            .Where(x => keys.Contains(x.Tag))
            .Select(x => new { x.Id, x.Tag });

        var ids = await asyncExecuter.ToListAsync(query, cancellationToken);
        var urls = ids.Select(x => new { x.Tag, Url = $"/{prefixUrl}/{x.Id}" });

        return urls.ToLookup(x => x.Tag, x => x.Url)!;
    }
}
