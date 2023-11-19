using FluentValidation;

namespace Rubrum.Abp.Keycloak.Users.Validators;

public class CreateKeycloakUserInputValidator : AbstractValidator<CreateKeycloakUserInput>
{
    public CreateKeycloakUserInputValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty();

        RuleFor(x => x.Email)
            .EmailAddress();
    }
}
