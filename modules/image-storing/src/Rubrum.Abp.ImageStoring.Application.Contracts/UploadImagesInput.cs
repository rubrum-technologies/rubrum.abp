using Volo.Abp.Content;

namespace Rubrum.Abp.ImageStoring;

public class UploadImagesInput
{
    public required IReadOnlyList<IRemoteStreamContent> Contents { get; set; }
    public string? Tag { get; init; }
    public bool IsDisposable { get; init; }
}
