using GreenDonut;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.ImageStoring;

public class ImageUrlByIdDataLoader :
    BatchDataLoader<Guid, string>,
    IImageUrlByIdDataLoader,
    IScopedDependency
{
    private readonly RubrumAbpImageStoringOptions _imageStoringOptions;

    public ImageUrlByIdDataLoader(
        IBatchScheduler batchScheduler,
        IOptions<RubrumAbpImageStoringOptions> imageStoringOptions,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _imageStoringOptions = imageStoringOptions.Value;
    }

    protected override Task<IReadOnlyDictionary<Guid, string>> LoadBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var prefixUrl = _imageStoringOptions.PrefixUrl.TrimStart('/').TrimEnd('/');
        var urls = keys.ToDictionary(x => x, x => $"/{prefixUrl}/{x}");
        return Task.FromResult<IReadOnlyDictionary<Guid, string>>(urls);
    }
}
