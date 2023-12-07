using Microsoft.Extensions.FileProviders;
using Shouldly;
using Volo.Abp.Content;
using Volo.Abp.VirtualFileSystem;
using Xunit;
using static Rubrum.Abp.ImageStoring.ImageStoringTestConstants;

namespace Rubrum.Abp.ImageStoring;

public class ImageAppServiceTests : ImageStoringApplicationTestBase
{
    private readonly IImageAppService _imageAppService;
    private readonly IImageContainer _imageContainer;
    private readonly IVirtualFileProvider _virtualFileProvider;

    public ImageAppServiceTests()
    {
        _imageContainer = GetRequiredService<IImageContainer>();
        _imageAppService = GetRequiredService<IImageAppService>();
        _virtualFileProvider = GetRequiredService<IVirtualFileProvider>();
    }

    [Fact]
    public async Task DownloadAsync()
    {
        foreach (var imageId in ImageIds)
        {
            var content = await _imageAppService.DownloadAsync(imageId);
            content.ShouldNotBeNull();
            content.ContentType.ShouldBe("image/webp");
        }

        var image = await _imageAppService.DownloadAsync(Guid.NewGuid());
        image.ShouldBeNull();
    }

    [Fact]
    public async Task CreateAsync()
    {
        var svgFile = _virtualFileProvider.GetFileInfo("/Files/1.svg");
        var jpegFile = _virtualFileProvider.GetFileInfo("/Files/2.jpeg");
        var jpgFile = _virtualFileProvider.GetFileInfo("/Files/3.jpg");
        var tifFile = _virtualFileProvider.GetFileInfo("/Files/4.tif");
        var pngFile = _virtualFileProvider.GetFileInfo("/Files/5.png");
        var gifFile = _virtualFileProvider.GetFileInfo("/Files/6.gif");

        await TestAsync(svgFile, "image/svg+xml");
        await TestAsync(jpegFile, "image/jpeg");
        await TestAsync(jpgFile, "image/jpeg");
        await TestAsync(tifFile, "image/tiff");
        await TestAsync(pngFile, "image/png");
        await TestAsync(gifFile, "image/gif");

        return;

        async Task TestAsync(IFileInfo file, string contentType)
        {
            var image = await _imageAppService.UploadAsync(new UploadImageInput
            {
                Content = new RemoteStreamContent(
                    file.CreateReadStream(),
                    string.Empty,
                    contentType)
            });
            var svgStream = await _imageContainer.GetAsync(image.Id);
            svgStream.ShouldNotBeNull();
            svgStream.Information.EntityVersion.ShouldBe(0);
        }
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var svgFile = _virtualFileProvider.GetFileInfo("/Files/1.svg");
        var jpegFile = _virtualFileProvider.GetFileInfo("/Files/2.jpeg");
        var jpgFile = _virtualFileProvider.GetFileInfo("/Files/3.jpg");
        var tifFile = _virtualFileProvider.GetFileInfo("/Files/4.tif");
        var pngFile = _virtualFileProvider.GetFileInfo("/Files/5.png");
        var gifFile = _virtualFileProvider.GetFileInfo("/Files/6.gif");

        await TestAsync(GifId, svgFile, "image/svg+xml");
        await TestAsync(PngId, jpegFile, "image/jpeg");
        await TestAsync(TifId, jpgFile, "image/jpeg");
        await TestAsync(JpgId, tifFile, "image/tiff");
        await TestAsync(JpegId, pngFile, "image/png");
        await TestAsync(SvgId, gifFile, "image/gif");

        return;

        async Task TestAsync(Guid id, IFileInfo file, string contentType)
        {
            await _imageAppService.UploadAsync(
                id,
                new RemoteStreamContent(
                    file.CreateReadStream(),
                    string.Empty,
                    contentType));
            var svgStream = await _imageContainer.GetAsync(id);
            svgStream.ShouldNotBeNull();
            svgStream.Information.EntityVersion.ShouldBe(1);
        }
    }

    [Fact]
    public async Task CreateAsync_Does_Not_Support_File_Extension()
    {
        await Assert.ThrowsAsync<NotSupportImageException>(async () =>
        {
            var file = _virtualFileProvider.GetFileInfo("/Files/test.md");

            await _imageAppService.UploadAsync(new UploadImageInput
            {
                Content = new RemoteStreamContent(file.CreateReadStream()),
            });
        });
    }
}
