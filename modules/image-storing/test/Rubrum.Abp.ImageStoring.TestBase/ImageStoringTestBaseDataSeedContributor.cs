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

        await _imageContainer.CreateAsync(new ImageFile(SvgId, svg.CreateReadStream(), "1.svg",ImageTag), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(JpegId, jpeg.CreateReadStream(), "2.jpeg"), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(JpgId, jpg.CreateReadStream(), "3.jpg", ImageTag), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(TifId, tif.CreateReadStream(), "4.tif"), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(PngId, png.CreateReadStream(), "5.png", ImageTag), cancellationToken);
        await _imageContainer.CreateAsync(new ImageFile(GifId, gif.CreateReadStream() ,"6.gif"), cancellationToken);
    }
}
