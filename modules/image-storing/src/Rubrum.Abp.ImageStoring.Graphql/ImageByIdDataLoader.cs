using GreenDonut;
using Rubrum.Abp.ImageStoring.Mapper.Interfaces;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace Rubrum.Abp.ImageStoring;

public class ImageByIdDataLoader : BatchDataLoader<Guid, ImageInformationDto>, IImageByIdDataLoader, IScopedDependency
{
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    private readonly IImageInformationRepository _repository;
    private readonly IImageMapper _mapper;

    public ImageByIdDataLoader(
        IBatchScheduler batchScheduler,
        IUnitOfWorkManager unitOfWorkManager,
        IImageInformationRepository repository,
        IImageMapper mapper,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _unitOfWorkManager = unitOfWorkManager;
        _repository = repository;
        _mapper = mapper;
    }

    protected override async Task<IReadOnlyDictionary<Guid, ImageInformationDto>> LoadBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        using var uow = _unitOfWorkManager.Begin(true);
        
        var images = await _repository.GetListAsync(x => keys.Contains(x.Id), true, cancellationToken);

        return images.Select(_mapper.Map).ToDictionary(x => x.Id, x => x);
    }
}
