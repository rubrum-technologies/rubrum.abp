using Shouldly;
using Volo.Abp.Imaging;
using Volo.Abp.VirtualFileSystem;
using Xunit;

namespace Rubrum.Abp.Imaging.MagickNet;

public class ImageConverterTests : ImagingMagickNetTestBase
{
    private static readonly string[] Files =
    {
        "/Files/1.svg", "/Files/2.jpeg", "/Files/3.jpg", "/Files/4.tif", "/Files/5.png", "/Files/6.gif"
    };

    private readonly IImageConverter _imageConverter;
    private readonly IVirtualFileProvider _virtualFileProvider;

    public ImageConverterTests()
    {
        _imageConverter = GetRequiredService<IImageConverter>();
        _virtualFileProvider = GetRequiredService<IVirtualFileProvider>();
    }

    [Fact]
    public async Task Convert_Streams()
    {
        foreach (var file in Files)
        {
            var stream = _virtualFileProvider.GetFileInfo(file).CreateReadStream();

            foreach (var format in Enum.GetValues<ImageFormat>())
            {
                var result = await _imageConverter.ConvertAsync(stream, format);

                result.State.ShouldBe(ImageProcessState.Done);

                var bytes = await result.Result.GetAllBytesAsync();
                bytes.Length.ShouldBeGreaterThan(0);
            }
        }
    }

    [Fact]
    public async Task Convert_Bytes()
    {
        foreach (var file in Files)
        {
            var stream = _virtualFileProvider.GetFileInfo(file).CreateReadStream();

            foreach (var format in Enum.GetValues<ImageFormat>())
            {
                var result = await _imageConverter.ConvertAsync(await stream.GetAllBytesAsync(), format);

                result.State.ShouldBe(ImageProcessState.Done);
                result.Result.Length.ShouldBeGreaterThan(0);
            }
        }
    }
}
