using GreenDonut;
using Rubrum.Abp.ImageStoring.Mapper.Interfaces;
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
    private readonly IImageMapper _mapper;

    public ImagesByTagDataLoader(
        IBatchScheduler batchScheduler,
        IImageInformationRepository imageRepository,
        IAsyncQueryableExecuter asyncExecuter,
        IImageMapper mapper,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _imageRepository = imageRepository;
        _asyncExecuter = asyncExecuter;
        _mapper = mapper;
    }

    protected override async Task<ILookup<string, ImageInformationDto>> LoadGroupedBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        var query = (await _imageRepository.GetQueryableAsync())
            .Where(x => keys.Contains(x.Tag));

        var result = await _asyncExecuter.ToListAsync(query, cancellationToken);

        return result.Select(_mapper.Map).ToLookup(x => x.Tag!, x => x);
    }
}
