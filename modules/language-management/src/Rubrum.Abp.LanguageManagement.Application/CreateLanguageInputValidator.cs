using FluentValidation;

namespace Rubrum.Abp.LanguageManagement;

public class CreateLanguageInputValidator : CreateOrUpdateLanguageInputValidatorBase<CreateLanguageInput>
{
    public CreateLanguageInputValidator()
    {
        RuleFor(x => x.Code)
            .MaximumLength(5)
            .NotEmpty();
    }
}
