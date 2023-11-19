using Mapster;
using Rubrum.Abp.Keycloak.Users;

namespace Rubrum.Abp.Keycloak.Mapper;

public class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserRepresentation, KeycloakUserDto>()
            .Map(x => x.UserName, x => x.Username)
            .Map(x => x.IsActive, x => x.Enabled);
    }
}
