using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Keycloak.Users;

public class KeycloakUserDto : EntityDto<string>
{
    public required string UserName { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public bool EmailVerified { get; init; }
    public string? PhoneNumber { get; init; }
    public bool PhoneNumberVerified { get; init; }
    public bool IsActive { get; init; }
}
