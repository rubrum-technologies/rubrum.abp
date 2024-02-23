using Volo.Abp.Content;

#nullable disable

namespace Rubrum.Abp.ImageStoring;

public class UploadImageInput
{
    public required IRemoteStreamContent Content { get; init; }

    public string Tag { get; init; }

    public bool IsDisposable { get; init; }
}
