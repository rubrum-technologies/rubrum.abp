namespace Rubrum.Abp.ImageStoring;

public interface IImageContainer
{
    Task<ImageFile> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ICollection<ImageFile>> GetByTagAsync(string tag, CancellationToken cancellationToken = default);

    Task<ImageFile?> GetOrNullAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ImageInformation> CreateAsync(ImageFile file, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid id, Stream stream, CancellationToken cancellationToken = default);

    Task UpdateTagAsync(Guid id, string? tag, CancellationToken cancellationToken = default);

    Task MarkAsPermanentAsync(Guid id, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task DeleteByTagAsync(string tag, CancellationToken cancellationToken = default);
}
