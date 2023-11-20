using FluentValidation;

namespace Rubrum.Abp.Keycloak.Roles.Validators;

public class CreateKeycloakRoleInputValidator : AbstractValidator<CreateKeycloakRoleInput>
{
    public CreateKeycloakRoleInputValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
