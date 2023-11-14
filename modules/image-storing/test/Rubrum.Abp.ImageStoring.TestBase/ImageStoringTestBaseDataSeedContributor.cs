using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;
using static Rubrum.Abp.ImageStoring.ImageStoringTestConstants;

namespace Rubrum.Abp.ImageStoring;

public class ImageStoringTestBaseDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ICancellationTokenProvider _cancellationTokenProvider;
    private readonly ImageContainer _imageContainer;
    private readonly IVirtualFileProvider _virtualFileProvider;

    public ImageStoringTestBaseDataSeedContributor(
        IVirtualFileProvider virtualFileProvider,
        ImageContainer imageContainer,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        _virtualFileProvider = virtualFileProvider;
        _imageContainer = imageContainer;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var cancellationToken = _cancellationTokenProvider.Token;

        var svg = _virtualFileProvider.GetFileInfo("/Files/1.svg");
        var jpeg = _virtualFileProvider.GetFileInfo("/Files/2.jpeg");
        var jpg = _virtualFileProvider.GetFileInfo("/Files/3.jpg");
        var tif = _virtualFileProvider.GetFileInfo("/Files/4.tif");
        var png = _virtualFileProvider.GetFileInfo("/Files/5.png");
        var gif = _virtualFileProvider.GetFileInfo("/Files/6.gif");

        await _imageContainer.CreateAsync(new ImageFile(SvgId, svg.CreateReadStream(), ImageTag), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(JpegId, jpeg.CreateReadStream()), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(JpgId, jpg.CreateReadStream(), ImageTag), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(TifId, tif.CreateReadStream()), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(PngId, png.CreateReadStream(), ImageTag), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(GifId, gif.CreateReadStream()), cancellationToken);
    }
}
