using FluentValidation;

namespace Rubrum.Abp.LanguageManagement;

public class CreateSystemLanguageInputValidator : CreateOrUpdateSystemLanguageInputValidatorBase<CreateSystemLanguageInput>
{
    public CreateSystemLanguageInputValidator()
    {
        RuleFor(x => x.Code)
            .MaximumLength(5)
            .NotEmpty();
    }
}
