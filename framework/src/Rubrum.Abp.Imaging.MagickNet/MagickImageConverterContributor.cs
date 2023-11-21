using ImageMagick;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Imaging;

namespace Rubrum.Abp.Imaging.MagickNet;

public class MagickImageConverterContributor : IImageConverterContributor, ITransientDependency
{
    public async Task<ImageConvertResult<Stream>> TryConvertAsync(
        Stream stream,
        ImageFormat final,
        ImageFormat? original = null,
        CancellationToken cancellationToken = default)
    {
        var memoryStream = await stream.CreateMemoryStreamAsync(cancellationToken);

        try
        {
            var result = await ConvertAsync(memoryStream, final, original, cancellationToken);

            return new ImageConvertResult<Stream>(result, ImageProcessState.Done);
        }
        catch (MagickMissingDelegateErrorException)
        {
            await memoryStream.DisposeAsync();
            return new ImageConvertResult<Stream>(stream, ImageProcessState.Unsupported);
        }
        catch
        {
            await memoryStream.DisposeAsync();
            throw;
        }
    }

    public async Task<ImageConvertResult<byte[]>> TryConvertAsync(
        byte[] bytes,
        ImageFormat final,
        ImageFormat? original = null,
        CancellationToken cancellationToken = default)
    {
        var memoryStream = new MemoryStream(bytes);

        try
        {
            var result = await ConvertAsync(memoryStream, final, original, cancellationToken);

            return new ImageConvertResult<byte[]>(
                await result.GetAllBytesAsync(cancellationToken),
                ImageProcessState.Done);
        }
        catch (MagickMissingDelegateErrorException)
        {
            await memoryStream.DisposeAsync();
            return new ImageConvertResult<byte[]>(bytes, ImageProcessState.Unsupported);
        }
        catch
        {
            await memoryStream.DisposeAsync();
            throw;
        }
    }

    protected virtual async Task<MemoryStream> ConvertAsync(
        Stream stream,
        ImageFormat to,
        ImageFormat? original = null,
        CancellationToken cancellationToken = default)
    {
        var memoryStream = new MemoryStream();

        try
        {
            var image = original is not null
                ? new MagickImage(stream, original.Value.ToMagick())
                : new MagickImage(stream);

            await image.WriteAsync(memoryStream, to.ToMagick(), cancellationToken);
            SeekToBegin(memoryStream);
            return memoryStream;
        }
        catch
        {
            await memoryStream.DisposeAsync();
            throw;
        }
    }

    protected virtual void SeekToBegin(Stream stream)
    {
        if (stream.CanSeek)
        {
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}
