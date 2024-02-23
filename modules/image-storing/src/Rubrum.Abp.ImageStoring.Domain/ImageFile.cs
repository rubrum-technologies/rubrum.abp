namespace Rubrum.Abp.ImageStoring;

public class ImageFile
{
    public ImageFile(Guid id, Stream stream, string? fileName = null, string? tag = null, bool isDisposable = false)
    {
        Information = new ImageInformation(id, tag) { FileName = fileName, IsDisposable = isDisposable };

        Stream = stream;
    }

    public ImageFile(Guid id, byte[] bytes, string? fileName = null, string? tag = null, bool isDisposable = false)
        : this(id, new MemoryStream(bytes), fileName, tag, isDisposable)
    {
    }

    internal ImageFile(ImageInformation information, Stream stream)
    {
        Information = information;
        Stream = stream;
    }

    public Guid Id => Information.Id;

    public string? Tag => Information.Tag;

    public string SystemFileName => Information.SystemFileName;

    public bool IsDisposable => Information.IsDisposable;

    public ImageInformation Information { get; }

    public Stream Stream { get; }
}
