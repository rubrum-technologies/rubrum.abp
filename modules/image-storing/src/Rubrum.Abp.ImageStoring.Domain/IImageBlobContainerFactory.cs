using Volo.Abp.BlobStoring;

namespace Rubrum.Abp.ImageStoring;

public interface IImageBlobContainerFactory
{
    Task<IBlobContainer> CreateAsync(ImageInformation information);
}
