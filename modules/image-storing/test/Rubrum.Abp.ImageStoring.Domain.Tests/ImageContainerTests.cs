﻿using Shouldly;
using Volo.Abp.VirtualFileSystem;
using Xunit;
using static Rubrum.Abp.ImageStoring.ImageStoringTestConstants;

namespace Rubrum.Abp.ImageStoring;

public class ImageContainerTests : ImageStoringDomainTestBase
{
    private readonly IImageContainer _imageContainer;
    private readonly IVirtualFileProvider _virtualFileProvider;

    public ImageContainerTests()
    {
        _imageContainer = GetRequiredService<IImageContainer>();
        _virtualFileProvider = GetRequiredService<IVirtualFileProvider>();
    }

    [Fact]
    public async Task GetAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            foreach (var imageId in ImageIds)
            {
                var image = await _imageContainer.GetAsync(imageId);
                image.ShouldNotBeNull();
                image.Information.ShouldNotBeNull();
            }
        });
    }

    [Fact]
    public async Task GetOrNullAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var image = await _imageContainer.GetOrNullAsync(Guid.NewGuid());
            image.ShouldBeNull();

            var gif = await _imageContainer.GetOrNullAsync(GifId);
            gif.ShouldNotBeNull();
        });
    }

    [Fact]
    public async Task GetByTagAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var image = await _imageContainer.GetByTagAsync(ImageTag);
            image.ShouldNotBeNull();
            image.Count.ShouldBe(3);
        });
    }

    [Fact]
    public async Task ExistsAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var exist = await _imageContainer.ExistsAsync(PngId);
            exist.ShouldBeTrue();

            var notExist = await _imageContainer.ExistsAsync(Guid.NewGuid());
            notExist.ShouldBeFalse();
        });
    }

    [Fact]
    public async Task CreateAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var jpeg = _virtualFileProvider.GetFileInfo("/Files/2.jpeg");
            var jpegId = Guid.NewGuid();
            await _imageContainer.CreateAsync(new ImageFile(jpegId, jpeg.CreateReadStream()));

            var jpegStream = await _imageContainer.GetOrNullAsync(jpegId);
            jpegStream.ShouldNotBeNull();
            jpegStream.Information.ShouldNotBeNull();
            jpegStream.Information.EntityVersion.ShouldBe(0);
        });
    }

    [Fact]
    public async Task UpdateAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var png = _virtualFileProvider.GetFileInfo("/Files/5.png");
            await _imageContainer.UpdateAsync(PngId, png.CreateReadStream());
        });

        var pngStream = await _imageContainer.GetOrNullAsync(PngId);
        pngStream.ShouldNotBeNull();
        pngStream.Information.ShouldNotBeNull();
    }

    [Fact]
    public async Task UpdateTagAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await _imageContainer.UpdateTagAsync(TifId, "Test");
            var image = await _imageContainer.GetAsync(TifId);
            image.Information.Tag.ShouldBe("Test");
            image.Information.EntityVersion.ShouldBe(1);
        });
    }

    [Fact]
    public async Task MarkAsPermanentAsync()
    {
        var jpeg = _virtualFileProvider.GetFileInfo("/Files/2.jpeg");
        var jpegId = Guid.NewGuid();
        await _imageContainer.CreateAsync(new ImageFile(jpegId, jpeg.CreateReadStream(), null, "test", true));

        var jpegStream = await _imageContainer.GetOrNullAsync(jpegId);
        jpegStream.ShouldNotBeNull();
        jpegStream.Information.ShouldNotBeNull();
        jpegStream.Information.IsDisposable.ShouldBeTrue();

        await _imageContainer.MarkAsPermanentAsync(jpegId);

        var image = await _imageContainer.GetAsync(jpegId);
        image.ShouldNotBeNull();
        image.Information.IsDisposable.ShouldBeFalse();
    }

    [Fact]
    public async Task DeleteAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await _imageContainer.DeleteAsync(SvgId);

            var svg = await _imageContainer.GetOrNullAsync(SvgId);
            svg.ShouldBeNull();
        });
    }
}
