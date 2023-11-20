namespace Rubrum.Abp.Keycloak.Users;

public class CreateKeycloakUserInput
{
    public required string UserName { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public bool? IsActive { get; init; }
    public string[]? RoleNames { get; init; }
}
