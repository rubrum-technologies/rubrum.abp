using Rubrum.Abp.Imaging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Imaging;

namespace Rubrum.Abp.ImageStoring;

public class ImageContainer(
    IImageConverter imageConverter,
    IImageInformationRepository imageRepository,
    IImageBlobContainerFactory imageBlobContainerFactory)
    : IImageContainer, ITransientDependency
{
    public async Task<ImageFile> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var information = await imageRepository.GetAsync(id, true, cancellationToken);
        var blobContainer = await imageBlobContainerFactory.CreateAsync(information);
        var stream = await blobContainer.GetAsync(information.SystemFileName, cancellationToken);

        return new ImageFile(information, stream);
    }

    public async Task<ICollection<ImageFile>> GetByTagAsync(
        string tag,
        CancellationToken cancellationToken = default)
    {
        var images = await imageRepository.GetListAsync(x => x.Tag == tag, true, cancellationToken);
        var streams = new List<ImageFile>();

        foreach (var information in images)
        {
            var blobContainer = await imageBlobContainerFactory.CreateAsync(information);
            var stream = await blobContainer.GetAsync(information.SystemFileName, cancellationToken);
            streams.Add(new ImageFile(information, stream));
        }

        return streams;
    }

    public async Task<ImageFile?> GetOrNullAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var information = await imageRepository.FindAsync(id, true, cancellationToken);

        if (information is null)
        {
            return null;
        }

        var blobContainer = await imageBlobContainerFactory.CreateAsync(information);
        var stream = await blobContainer.GetAsync(information.SystemFileName, cancellationToken);

        return new ImageFile(information, stream);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return imageRepository.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ImageInformation> CreateAsync(ImageFile file, CancellationToken cancellationToken = default)
    {
        var information = file.Information;
        var blobContainer = await imageBlobContainerFactory.CreateAsync(information);

        await using var stream = await CreateImageAsync(file.Stream);
        await blobContainer.SaveAsync(
            information.SystemFileName,
            stream,
            true,
            cancellationToken);

        return information;
    }

    public Task ChangeImageAsync(
        ImageInformation information,
        byte[] image,
        CancellationToken cancellationToken = default)
    {
        using var stream = new MemoryStream(image);

        return ChangeImageAsync(information, stream, cancellationToken);
    }

    public async Task ChangeImageAsync(
        ImageInformation information,
        Stream image,
        CancellationToken cancellationToken = default)
    {
        var blobContainer = await imageBlobContainerFactory.CreateAsync(information);

        await blobContainer.SaveAsync(
            information.SystemFileName,
            await CreateImageAsync(image),
            true,
            cancellationToken);
        await imageRepository.UpdateAsync(information, true, cancellationToken);
    }

    public async Task ChangeTagAsync(
        ImageInformation information,
        string? tag,
        CancellationToken cancellationToken = default)
    {
        var blobContainer = await imageBlobContainerFactory.CreateAsync(information);
        await using var file = await blobContainer.GetAsync(information.SystemFileName, cancellationToken);

        if (information.Tag == tag)
        {
            return;
        }

        await blobContainer.DeleteAsync(information.SystemFileName, cancellationToken);

        information.Tag = tag;

        blobContainer = await imageBlobContainerFactory.CreateAsync(information);

        await blobContainer.SaveAsync(information.SystemFileName, file, true, cancellationToken);
        await imageRepository.UpdateAsync(information, true, cancellationToken);
    }

    protected virtual async Task<Stream> CreateImageAsync(Stream stream)
    {
        var result = await imageConverter.ConvertAsync(stream, ImageFormat.WebP);

        if (result.State == ImageProcessState.Unsupported)
        {
            throw new NotSupportImageException();
        }

        return result.Result;
    }
}
