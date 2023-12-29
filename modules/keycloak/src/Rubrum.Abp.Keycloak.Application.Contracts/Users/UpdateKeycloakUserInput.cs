namespace Rubrum.Abp.Keycloak.Users;

public class UpdateKeycloakUserInput
{
    public string? UserName { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Email { get; init; }

    public string? PhoneNumber { get; init; }

    public bool? IsActive { get; init; }
}
