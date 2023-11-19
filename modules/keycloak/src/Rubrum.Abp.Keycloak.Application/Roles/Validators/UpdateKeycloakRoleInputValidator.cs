using FluentValidation;

namespace Rubrum.Abp.Keycloak.Roles.Validators;

public class UpdateKeycloakRoleInputValidator : AbstractValidator<UpdateKeycloakRoleInput>
{
    public UpdateKeycloakRoleInputValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
