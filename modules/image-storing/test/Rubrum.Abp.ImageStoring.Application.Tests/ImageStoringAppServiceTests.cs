using Microsoft.Extensions.FileProviders;
using Shouldly;
using Volo.Abp.Content;
using Volo.Abp.VirtualFileSystem;
using Xunit;
using static Rubrum.Abp.ImageStoring.ImageStoringTestConstants;

namespace Rubrum.Abp.ImageStoring;

public sealed class ImageStoringAppServiceTests : ImageStoringApplicationTestBase
{
    private readonly IImageStoringAppService _imageStoringAppService;
    private readonly IImageContainer _imageContainer;
    private readonly IVirtualFileProvider _virtualFileProvider;

    public ImageStoringAppServiceTests()
    {
        _imageContainer = GetRequiredService<IImageContainer>();
        _imageStoringAppService = GetRequiredService<IImageStoringAppService>();
        _virtualFileProvider = GetRequiredService<IVirtualFileProvider>();
    }

    [Fact]
    public async Task GetAsync()
    {
        var image = await _imageStoringAppService.GetAsync(TifId);
        var dbImage = await _imageContainer.GetAsync(TifId);

        image.ShouldNotBeNull();
        image.Tag.ShouldBe(dbImage.Tag);
        image.FileName.ShouldBe(dbImage.Information.FileName);
        image.IsDisposable.ShouldBe(dbImage.IsDisposable);
    }

    [Fact]
    public async Task GetByTagAsync()
    {
        var images = await _imageStoringAppService.GetByTagAsync(ImageTag);
        var dbImages = await _imageContainer.GetByTagAsync(ImageTag);

        foreach (var dbImage in dbImages)
        {
            var image = images.Items.SingleOrDefault(x => x.Id == dbImage.Id);

            image.ShouldNotBeNull();
            image.Tag.ShouldBe(dbImage.Tag);
            image.FileName.ShouldBe(dbImage.Information.FileName);
            image.IsDisposable.ShouldBe(dbImage.IsDisposable);
        }
    }

    [Fact]
    public async Task GetListAsync()
    {
        var images = await _imageStoringAppService.GetListAsync();

        foreach (var imageId in ImageIds)
        {
            var image = images.Items.SingleOrDefault(x => x.Id == imageId);
            var dbImage = await _imageContainer.GetAsync(imageId);

            image.ShouldNotBeNull();
            image.Tag.ShouldBe(dbImage.Tag);
            image.FileName.ShouldBe(dbImage.Information.FileName);
            image.IsDisposable.ShouldBe(dbImage.IsDisposable);
        }
    }

    [Fact]
    public async Task DownloadAsync()
    {
        foreach (var imageId in ImageIds)
        {
            var content = await _imageStoringAppService.DownloadAsync(imageId);
            content.ShouldNotBeNull();
            content.ContentType.ShouldBe("image/webp");
        }

        var image = await _imageStoringAppService.DownloadAsync(Guid.NewGuid());
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

        async Task TestAsync(IFileInfo file, string contentType)
        {
            var image = await _imageStoringAppService.UploadAsync(new UploadImageInput
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

        async Task TestAsync(Guid id, IFileInfo file, string contentType)
        {
            await _imageStoringAppService.UploadAsync(
                id,
                new RemoteStreamContent(
                    file.CreateReadStream(),
                    string.Empty,
                    contentType));
            var svgStream = await _imageContainer.GetAsync(id);
            svgStream.ShouldNotBeNull();
        }
    }

    [Fact]
    public async Task UploadAsync()
    {
        var jpgFile = _virtualFileProvider.GetFileInfo("/Files/3.jpg");

        var result = await _imageStoringAppService.UploadAsync(new UploadImageInput
        {
            Content = new RemoteStreamContent(jpgFile.CreateReadStream())
        });

        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task UploadManyAsync()
    {
        var jpegFile = _virtualFileProvider.GetFileInfo("/Files/2.jpeg");
        var jpgFile = _virtualFileProvider.GetFileInfo("/Files/3.jpg");
        var tifFile = _virtualFileProvider.GetFileInfo("/Files/4.tif");
        var pngFile = _virtualFileProvider.GetFileInfo("/Files/5.png");
        var gifFile = _virtualFileProvider.GetFileInfo("/Files/6.gif");

        var result = await _imageStoringAppService.UploadManyAsync(new UploadImagesInput
        {
            Contents = new[]
            {
                new RemoteStreamContent(jpegFile.CreateReadStream()),
                new RemoteStreamContent(jpgFile.CreateReadStream()),
                new RemoteStreamContent(tifFile.CreateReadStream()),
                new RemoteStreamContent(pngFile.CreateReadStream()),
                new RemoteStreamContent(gifFile.CreateReadStream()),
            }
        });

        result.ShouldNotBeNull();
        result.Items.Count.ShouldBe(5);
    }

    [Fact]
    public async Task ChangeTagAsync()
    {
        await _imageStoringAppService.ChangeTagAsync(new ChangeTagInput
        {
            Ids = [SvgId, JpegId, PngId, TifId],
            Tag = "Test"
        });

        foreach (var id in new[] { SvgId, JpegId, PngId, TifId })
        {
            var image = await _imageContainer.GetOrNullAsync(id);

            image.ShouldNotBeNull();
            image.Tag.ShouldBe("Test");
        }
    }

    [Fact]
    public async Task DeleteAsync()
    {
        await _imageStoringAppService.DeleteAsync(SvgId);

        var image = await _imageContainer.GetOrNullAsync(SvgId);

        image.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteByTagAsync()
    {
        var images = await _imageContainer.GetByTagAsync(ImageTag);

        await _imageStoringAppService.DeleteByTagAsync(ImageTag);

        foreach (var image in images)
        {
            (await _imageContainer.GetOrNullAsync(image.Id)).ShouldBeNull();
        }
    }

    [Fact]
    public async Task CreateAsync_Does_Not_Support_File_Extension()
    {
        await Assert.ThrowsAsync<NotSupportImageException>(async () =>
        {
            var file = _virtualFileProvider.GetFileInfo("/Files/test.md");

            await _imageStoringAppService.UploadAsync(new UploadImageInput
            {
                Content = new RemoteStreamContent(file.CreateReadStream()),
            });
        });
    }
}
