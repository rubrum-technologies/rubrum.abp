using Mapster;
using Rubrum.Abp.Keycloak.Users;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Keycloak.Mapper.Interfaces;

[Mapper]
public interface IKeycloakUserMapper : ITransientDependency
{
    KeycloakUserDto Map(UserRepresentation user);
}
