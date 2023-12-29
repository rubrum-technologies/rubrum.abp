using Mapster;

namespace Rubrum.Abp.ImageStoring.Mapper;

public class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ImageFile, ImageInformationDto>()
            .Ignore(x => x.ExtraProperties)
            .Map(x => x, x => x.Information);

        config.NewConfig<ImageInformation, ImageInformationDto>()
            .Ignore(x => x.ExtraProperties);
    }
}
