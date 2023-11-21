namespace Rubrum.Abp.Imaging;

public interface IImageConverter
{
    Task<ImageConvertResult<Stream>> ConvertAsync(
        Stream stream,
        ImageFormat final,
        ImageFormat? original = null,
        CancellationToken cancellationToken = default);

    Task<ImageConvertResult<byte[]>> ConvertAsync(
        byte[] bytes,
        ImageFormat final,
        ImageFormat? original = null,
        CancellationToken cancellationToken = default);
}
