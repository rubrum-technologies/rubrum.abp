namespace Rubrum.Abp.Imaging;

public interface IImageConverterContributor
{
    Task<ImageConvertResult<Stream>> TryConvertAsync(
        Stream stream,
        ImageFormat final,
        ImageFormat? original = null, 
        CancellationToken cancellationToken = default);

    Task<ImageConvertResult<byte[]>> TryConvertAsync(
        byte[] bytes,
        ImageFormat final,
        ImageFormat? original = null, 
        CancellationToken cancellationToken = default);
}
