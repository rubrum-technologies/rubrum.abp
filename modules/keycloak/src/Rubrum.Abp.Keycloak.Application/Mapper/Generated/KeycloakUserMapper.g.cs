using Rubrum.Abp.Keycloak;
using Rubrum.Abp.Keycloak.Mapper.Interfaces;
using Rubrum.Abp.Keycloak.Users;

namespace Rubrum.Abp.Keycloak.Mapper.Interfaces
{
    public partial class KeycloakUserMapper : IKeycloakUserMapper
    {
        public KeycloakUserDto Map(UserRepresentation p1)
        {
            return p1 == null ? null : new KeycloakUserDto()
            {
                UserName = p1.Username,
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Email = p1.Email,
                EmailVerified = p1.EmailVerified == null ? false : (bool)p1.EmailVerified,
                IsActive = p1.Enabled == null ? false : (bool)p1.Enabled,
                Id = p1.Id
            };
        }
    }
}