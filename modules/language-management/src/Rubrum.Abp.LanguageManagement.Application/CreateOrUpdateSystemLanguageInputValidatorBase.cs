using FluentValidation;
using static Rubrum.Abp.LanguageManagement.SystemLanguageConstants;

namespace Rubrum.Abp.LanguageManagement;

public abstract class CreateOrUpdateSystemLanguageInputValidatorBase<TInput> : AbstractValidator<TInput>
    where TInput : CreateOrUpdateSystemLanguageInputBase
{
    protected CreateOrUpdateSystemLanguageInputValidatorBase()
    {
        RuleFor(x => x.Name)
            .MaximumLength(MaxNameLenght)
            .NotEmpty();
    }
}
