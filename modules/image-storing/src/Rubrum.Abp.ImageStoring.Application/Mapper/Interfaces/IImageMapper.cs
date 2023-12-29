using Mapster;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.ImageStoring.Mapper.Interfaces;

[Mapper]
public interface IImageMapper : ITransientDependency
{
    ImageInformationDto Map(ImageInformation image);

    ImageInformationDto Map(ImageFile file);
}
