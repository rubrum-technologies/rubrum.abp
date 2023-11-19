using Rubrum.Abp.Keycloak;
using Rubrum.Abp.Keycloak.Mapper.Interfaces;
using Rubrum.Abp.Keycloak.Roles;

namespace Rubrum.Abp.Keycloak.Mapper.Interfaces
{
    public partial class KeycloakRoleMapper : IKeycloakRoleMapper
    {
        public KeycloakRoleDto Map(RoleRepresentation p1)
        {
            return p1 == null ? null : new KeycloakRoleDto()
            {
                Name = p1.Name,
                Id = p1.Id
            };
        }
    }
}