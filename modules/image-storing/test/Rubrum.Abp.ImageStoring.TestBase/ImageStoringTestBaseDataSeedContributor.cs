using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;
using static Rubrum.Abp.ImageStoring.ImageStoringTestConstants;

namespace Rubrum.Abp.ImageStoring;

public class ImageStoringTestBaseDataSeedContributor(
    IImageInformationRepository repository,
    IVirtualFileProvider virtualFileProvider,
    IImageContainer imageContainer)
    : IDataSeedContributor, ITransientDependency
{
    public async Task SeedAsync(DataSeedContext context)
    {
        var svg = virtualFileProvider.GetFileInfo("/Files/1.svg");
        var jpeg = virtualFileProvider.GetFileInfo("/Files/2.jpeg");
        var jpg = virtualFileProvider.GetFileInfo("/Files/3.jpg");
        var tif = virtualFileProvider.GetFileInfo("/Files/4.tif");
        var png = virtualFileProvider.GetFileInfo("/Files/5.png");
        var gif = virtualFileProvider.GetFileInfo("/Files/6.gif");

        await repository.InsertAsync(
            await imageContainer.CreateAsync(new ImageFile(SvgId, svg.CreateReadStream(), "1.svg", ImageTag)));

        await repository.InsertAsync(
            await imageContainer.CreateAsync(new ImageFile(JpegId, jpeg.CreateReadStream(), "2.jpeg")));

        await repository.InsertAsync(
            await imageContainer.CreateAsync(new ImageFile(JpgId, jpg.CreateReadStream(), "3.jpg", ImageTag)));

        await repository.InsertAsync(
            await imageContainer.CreateAsync(new ImageFile(TifId, tif.CreateReadStream(), "4.tif")));

        await repository.InsertAsync(
            await imageContainer.CreateAsync(new ImageFile(PngId, png.CreateReadStream(), "5.png", ImageTag)));

        await repository.InsertAsync(
            await imageContainer.CreateAsync(new ImageFile(GifId, gif.CreateReadStream(), "6.gif")));
    }
}
