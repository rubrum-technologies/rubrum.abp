using Volo.Abp.Content;

namespace Rubrum.Abp.ImageStoring;

public class UploadImagesInput
{
    public IEnumerable<IRemoteStreamContent> Contents { get; init; } = new List<IRemoteStreamContent>();
    public string? Tag { get; init; }
    public bool IsDisposable { get; init; } = true;
}
