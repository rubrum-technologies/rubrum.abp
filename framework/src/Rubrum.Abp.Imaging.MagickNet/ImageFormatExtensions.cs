using ImageMagick;

namespace Rubrum.Abp.Imaging.MagickNet;

public static class ImageFormatExtensions
{
    public static MagickFormat ToMagick(this ImageFormat format)
    {
        return format switch
        {
            ImageFormat.Bmp => MagickFormat.Bmp,
            ImageFormat.Gif => MagickFormat.Gif,
            ImageFormat.Jpeg => MagickFormat.Jpeg,
            ImageFormat.Png => MagickFormat.Png,
            ImageFormat.Svg => MagickFormat.Svg,
            ImageFormat.Tiff => MagickFormat.Tiff,
            ImageFormat.WebP => MagickFormat.WebP,
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }
}
