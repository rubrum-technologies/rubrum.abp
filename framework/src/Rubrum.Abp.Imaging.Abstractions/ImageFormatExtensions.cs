using Volo.Abp.Http;

namespace Rubrum.Abp.Imaging;

public static class ImageFormatExtensions
{
    public static string ToMimeType(this ImageFormat format)
    {
        return format switch
        {
            ImageFormat.Bmp => MimeTypes.Image.Bmp,
            ImageFormat.Gif => MimeTypes.Image.Gif,
            ImageFormat.Jpeg => MimeTypes.Image.Jpeg,
            ImageFormat.Png => MimeTypes.Image.Png,
            ImageFormat.Svg => MimeTypes.Image.SvgXml,
            ImageFormat.Tiff => MimeTypes.Image.Tiff,
            ImageFormat.WebP => MimeTypes.Image.Webp,
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }

    public static ImageFormat ToImageFormat(this string mimeType)
    {
        return mimeType switch
        {
            MimeTypes.Image.Bmp => ImageFormat.Bmp,
            MimeTypes.Image.Gif => ImageFormat.Gif,
            MimeTypes.Image.Jpeg => ImageFormat.Jpeg,
            MimeTypes.Image.Png => ImageFormat.Png,
            MimeTypes.Image.SvgXml => ImageFormat.Svg,
            MimeTypes.Image.Tiff => ImageFormat.Tiff,
            MimeTypes.Image.Webp => ImageFormat.WebP,
            _ => throw new ArgumentOutOfRangeException(nameof(mimeType), mimeType, null)
        };
    }
}
