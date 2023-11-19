using FluentValidation;

namespace Rubrum.Abp.Keycloak.Users.Validators;

public class ChangeRolesKeycloakUserInputValidator : AbstractValidator<ChangeRolesKeycloakUserInput>
{
    public ChangeRolesKeycloakUserInputValidator()
    {
        RuleFor(x => x.RoleNames)
            .NotNull();
    }
}
