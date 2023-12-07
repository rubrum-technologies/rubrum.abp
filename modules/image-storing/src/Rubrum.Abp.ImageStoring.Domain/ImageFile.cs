namespace Rubrum.Abp.ImageStoring;

public class ImageFile
{
    internal ImageFile(ImageInformation information, Stream stream)
    {
        Information = information;
        Stream = stream;
    }

    public ImageFile(Guid id, Stream stream, string? tag = null, bool isDisposable = false)
    {
        Information = new ImageInformation(id, tag)
        {
            IsDisposable = isDisposable
        };
        
        Stream = stream;
    }

    public ImageInformation Information { get; }

    public Stream Stream { get; }
}
