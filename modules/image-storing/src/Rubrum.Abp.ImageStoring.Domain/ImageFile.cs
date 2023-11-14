namespace Rubrum.Abp.ImageStoring;

public class ImageFile
{
    internal ImageFile(ImageInformation information, Stream stream)
    {
        Information = information;
        Stream = stream;
    }

    public ImageFile(Guid id, Stream stream, string? tag = null)
    {
        Information = new ImageInformation(id, tag);
        Stream = stream;
    }

    public ImageInformation Information { get; }

    public Stream Stream { get; }
}
