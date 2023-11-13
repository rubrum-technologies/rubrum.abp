using FluentValidation;

namespace Rubrum.Abp.Graphql.Model;

public class CreateCountryInputValidator : AbstractValidator<CreateCountryInput>
{
    public CreateCountryInputValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(20)
            .WithName("Maximum length 20");

        RuleFor(x => x.Name)
            .MinimumLength(1);

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
