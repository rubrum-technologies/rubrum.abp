using FluentValidation;
using static Rubrum.Abp.LanguageManagement.LanguageConstants;

namespace Rubrum.Abp.LanguageManagement;

public abstract class CreateOrUpdateLanguageInputValidatorBase<TInput> : AbstractValidator<TInput>
    where TInput: CreateOrUpdateLanguageInputBase
{
    protected CreateOrUpdateLanguageInputValidatorBase()
    {
        RuleFor(x=>x.Name)
            .MaximumLength(MaxNameLenght)
            .NotEmpty();
    }
}
