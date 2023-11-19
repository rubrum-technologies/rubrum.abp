using FluentValidation;

namespace Rubrum.Abp.Keycloak.Users.Validators;

public class UpdateKeycloakUserInputValidator : AbstractValidator<UpdateKeycloakUserInput>
{
    public UpdateKeycloakUserInputValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress();
    }
}
