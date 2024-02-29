using System.Linq.Expressions;
using Mapster;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.ImageStoring.Mapper;

[Mapper]
public interface IImageInformationMapper : ITransientDependency
{
    Expression<Func<ImageInformation, ImageInformationDto>> Projection { get; }

    ImageInformationDto Map(ImageInformation image);

    ImageInformationDto Map(ImageFile file);
}
