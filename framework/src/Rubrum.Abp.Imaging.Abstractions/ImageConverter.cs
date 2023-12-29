using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Imaging;
using Volo.Abp.Threading;

namespace Rubrum.Abp.Imaging;

public class ImageConverter : IImageConverter, ITransientDependency
{
    public ImageConverter(
        IEnumerable<IImageConverterContributor> imageConverterContributors,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        ImageConverterContributors = imageConverterContributors;
        CancellationTokenProvider = cancellationTokenProvider;
    }

    protected IEnumerable<IImageConverterContributor> ImageConverterContributors { get; }

    protected ICancellationTokenProvider CancellationTokenProvider { get; }

    public async Task<ImageConvertResult<Stream>> ConvertAsync(
        Stream stream,
        ImageFormat final,
        ImageFormat? original = null,
        CancellationToken cancellationToken = default)
    {
        Check.NotNull(stream, nameof(stream));

        if (!stream.CanRead)
        {
            return new ImageConvertResult<Stream>(stream, ImageProcessState.Unsupported);
        }

        if (!stream.CanSeek)
        {
            var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream, CancellationTokenProvider.FallbackToProvider(cancellationToken));
            SeekToBegin(memoryStream);
            stream = memoryStream;
        }

        foreach (var imageConverterContributor in ImageConverterContributors)
        {
            var result = await imageConverterContributor.TryConvertAsync(
                stream,
                final,
                original,
                CancellationTokenProvider.FallbackToProvider(cancellationToken));

            SeekToBegin(stream);

            if (result.State == ImageProcessState.Unsupported)
            {
                continue;
            }

            return result;
        }

        return new ImageConvertResult<Stream>(stream, ImageProcessState.Unsupported);
    }

    public async Task<ImageConvertResult<byte[]>> ConvertAsync(
        byte[] bytes,
        ImageFormat final,
        ImageFormat? original = null,
        CancellationToken cancellationToken = default)
    {
        Check.NotNull(bytes, nameof(bytes));

        foreach (var imageConverterContributor in ImageConverterContributors)
        {
            var result = await imageConverterContributor.TryConvertAsync(
                bytes,
                final,
                original,
                CancellationTokenProvider.FallbackToProvider(cancellationToken));

            if (result.State == ImageProcessState.Unsupported)
            {
                continue;
            }

            return result;
        }

        return new ImageConvertResult<byte[]>(bytes, ImageProcessState.Unsupported);
    }

    protected virtual void SeekToBegin(Stream stream)
    {
        if (stream.CanSeek)
        {
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}
