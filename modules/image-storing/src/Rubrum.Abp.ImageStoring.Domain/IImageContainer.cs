namespace Rubrum.Abp.ImageStoring;

public interface IImageContainer
{
    Task<ImageFile> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ICollection<ImageFile>> GetByTagAsync(string tag, CancellationToken cancellationToken = default);

    Task<ImageFile?> GetOrNullAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ImageInformation> CreateAsync(ImageFile file, CancellationToken cancellationToken = default);

    Task ChangeImageAsync(ImageInformation information, byte[] image, CancellationToken cancellationToken = default);

    Task ChangeImageAsync(ImageInformation information, Stream image, CancellationToken cancellationToken = default);

    Task ChangeTagAsync(ImageInformation information, string? tag, CancellationToken cancellationToken = default);
}
