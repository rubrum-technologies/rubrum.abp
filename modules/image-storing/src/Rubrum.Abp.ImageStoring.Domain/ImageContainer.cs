using Rubrum.Abp.Imaging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Imaging;

namespace Rubrum.Abp.ImageStoring;

public class ImageContainer : IImageContainer, ITransientDependency
{
    private readonly IImageBlobContainerFactory _imageBlobContainerFactory;
    private readonly IImageConverter _imageConverter;
    private readonly IImageInformationRepository _imageRepository;

    public ImageContainer(
        IImageConverter imageConverter,
        IImageInformationRepository imageRepository,
        IImageBlobContainerFactory imageBlobContainerFactory)
    {
        _imageConverter = imageConverter;
        _imageRepository = imageRepository;
        _imageBlobContainerFactory = imageBlobContainerFactory;
    }

    public async Task<ImageFile> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var information = await _imageRepository.GetAsync(id, true, cancellationToken);
        var blobContainer = await _imageBlobContainerFactory.CreateAsync(information);
        var stream = await blobContainer.GetAsync(information.SystemFileName, cancellationToken);

        return new ImageFile(information, stream);
    }

    public async Task<ICollection<ImageFile>> GetByTagAsync(
        string tag,
        CancellationToken cancellationToken = default)
    {
        var images = await _imageRepository.GetListAsync(x => x.Tag == tag, true, cancellationToken);
        var streams = new List<ImageFile>();

        foreach (var information in images)
        {
            var blobContainer = await _imageBlobContainerFactory.CreateAsync(information);
            var stream = await blobContainer.GetAsync(information.SystemFileName, cancellationToken);
            streams.Add(new ImageFile(information, stream));
        }

        return streams;
    }

    public async Task<ImageFile?> GetOrNullAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var information = await _imageRepository.FindAsync(id, true, cancellationToken);

        if (information is null)
        {
            return null;
        }

        var blobContainer = await _imageBlobContainerFactory.CreateAsync(information);
        var stream = await blobContainer.GetAsync(information.SystemFileName, cancellationToken);

        return new ImageFile(information, stream);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _imageRepository.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ImageInformation> CreateAsync(ImageFile file, CancellationToken cancellationToken = default)
    {
        var information = file.Information;
        var blobContainer = await _imageBlobContainerFactory.CreateAsync(information);

        await using var stream = await CreateImageAsync(file.Stream);
        await blobContainer.SaveAsync(
            information.SystemFileName,
            stream,
            true,
            cancellationToken);
        await _imageRepository.InsertAsync(information, true, cancellationToken);

        return information;
    }

    public async Task UpdateAsync(
        Guid id,
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        var information = await _imageRepository.GetAsync(id, true, cancellationToken);
        var blobContainer = await _imageBlobContainerFactory.CreateAsync(information);

        await blobContainer.SaveAsync(
            information.SystemFileName,
            await CreateImageAsync(stream),
            true,
            cancellationToken);
        await _imageRepository.UpdateAsync(information, true, cancellationToken);
    }

    public async Task UpdateTagAsync(Guid id, string? tag, CancellationToken cancellationToken = default)
    {
        var file = await GetAsync(id, cancellationToken);
        var information = file.Information;

        var blobContainer = await _imageBlobContainerFactory.CreateAsync(information);
        await blobContainer.DeleteAsync(information.SystemFileName, cancellationToken);

        information.Tag = tag;

        blobContainer = await _imageBlobContainerFactory.CreateAsync(information);

        await blobContainer.SaveAsync(information.SystemFileName, file.Stream, true, cancellationToken);
        await _imageRepository.UpdateAsync(information, true, cancellationToken);
    }

    public async Task MarkAsPermanentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var information = await _imageRepository.GetAsync(id, true, cancellationToken);
        
        information.IsDisposable = false;
        
        await _imageRepository.UpdateAsync(information, true, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var information = await _imageRepository.GetAsync(id, true, cancellationToken);
        var blobContainer = await _imageBlobContainerFactory.CreateAsync(information);

        await _imageRepository.DeleteAsync(information, true, cancellationToken);
        await blobContainer.DeleteAsync(information.SystemFileName, cancellationToken);
    }

    protected virtual async Task<Stream> CreateImageAsync(Stream stream)
    {
        var result = await _imageConverter.ConvertAsync(stream, ImageFormat.WebP);

        if (result.State == ImageProcessState.Unsupported)
        {
            throw new NotSupportImageException();
        }

        return result.Result;
    }
}
