namespace Rubrum.Abp.Keycloak.Users;

public class ChangeRolesKeycloakUserInput
{
    public required string[] RoleNames { get; init; }
}
