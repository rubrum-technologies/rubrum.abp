using FluentValidation;

namespace Rubrum.Abp.Keycloak.Users.Validators;

public class ChangePasswordKeycloakUserInputValidator : AbstractValidator<ChangePasswordKeycloakUserInput>
{
    public ChangePasswordKeycloakUserInputValidator()
    {
        RuleFor(x => x.Password)
            .MinimumLength(3)
            .NotEmpty();
    }
}
