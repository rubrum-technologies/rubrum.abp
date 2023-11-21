using Mapster;

namespace Rubrum.Abp.LanguageManagement.Mapper;

public class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SystemLanguage, SystemLanguageDto>();
    }
}
