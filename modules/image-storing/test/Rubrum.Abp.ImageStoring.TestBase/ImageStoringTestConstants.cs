namespace Rubrum.Abp.ImageStoring;

public static class ImageStoringTestConstants
{
    public static string ImageTag { get; } = Guid.NewGuid().ToString();

    public static Guid SvgId { get; } = Guid.NewGuid();

    public static Guid JpegId { get; } = Guid.NewGuid();

    public static Guid JpgId { get; } = Guid.NewGuid();

    public static Guid TifId { get; } = Guid.NewGuid();

    public static Guid PngId { get; } = Guid.NewGuid();

    public static Guid GifId { get; } = Guid.NewGuid();

    public static Guid[] ImageIds => new[] { SvgId, JpegId, JpgId, TifId, PngId, GifId };
}
