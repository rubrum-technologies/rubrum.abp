using Microsoft.Extensions.Options;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.ImageStoring;

public class ImageBlobContainerFactory : IImageBlobContainerFactory, ITransientDependency
{
    private readonly IBlobContainerFactory _blobContainerFactory;
    private readonly RubrumAbpImageStoringOptions _options;

    public ImageBlobContainerFactory(
        IBlobContainerFactory blobContainerFactory,
        IOptions<RubrumAbpImageStoringOptions> options)
    {
        _blobContainerFactory = blobContainerFactory;
        _options = options.Value;
    }

    public Task<IBlobContainer> CreateAsync(ImageInformation information)
    {
        var name = string.IsNullOrEmpty(information.Tag)
            ? _options.NameContainer
            : $"{_options.NameContainer}-{information.Tag}";

        return Task.FromResult(_blobContainerFactory.Create(name));
    }
}
