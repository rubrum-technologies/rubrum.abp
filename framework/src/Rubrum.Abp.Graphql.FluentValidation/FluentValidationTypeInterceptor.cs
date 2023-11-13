using FluentValidation;
using FluentValidation.Validators;
using HotChocolate.Configuration;
using HotChocolate.Resolvers;
using HotChocolate.Types.Descriptors.Definitions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.Graphql.Localization.Rubrum.Abp.Graphql;

namespace Rubrum.Abp.Graphql;

public class FluentValidationTypeInterceptor : TypeInterceptor
{
    public override void OnAfterCompleteName(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        if (definition is not InputObjectTypeDefinition inputType)
        {
            return;
        }

        var (validator, _) = GetValidator(completionContext, inputType.RuntimeType);

        if (validator is null)
        {
            return;
        }

        var descriptions = GetDescriptions(completionContext, validator);

        foreach (var (propertyName, values) in descriptions)
        {
            var field = inputType.Fields.FirstOrDefault(x => x.Property?.Name == propertyName);

            if (field is null)
            {
                continue;
            }

            field.Description = string.Join(",\n ", values);
        }
    }

    public override void OnBeforeCompleteType(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        if (definition is not ObjectTypeDefinition objectType)
        {
            return;
        }

        foreach (var field in objectType.Fields)
        {
            var isNotNullValidator = false;

            foreach (var argument in field.Arguments)
            {
                var runtimeType = argument.TryGetRuntimeType();

                if (runtimeType is null)
                {
                    continue;
                }

                var (validator, type) = GetValidator(completionContext, runtimeType);

                if (validator is null)
                {
                    continue;
                }

                isNotNullValidator = true;
                AddValidatorType(argument, type);
            }

            if (isNotNullValidator)
            {
                AddMiddleware(field);
            }
        }
    }

    private static (IValidator? validator, Type Type) GetValidator(
        ITypeCompletionContext completionContext,
        Type runtimeType)
    {
        var type = typeof(IValidator<>).MakeGenericType(runtimeType);
        var validator = (IValidator?)completionContext.Services.GetService(type);

        return (validator, type);
    }

    private static Dictionary<string, List<string>> GetDescriptions(
        ITypeCompletionContext completionContext,
        IValidator validator)
    {
        var result = new Dictionary<string, List<string>>();

        if (validator is not IEnumerable<IValidationRule> rules)
        {
            return result;
        }

        var localizer = completionContext.Services.GetRequiredService<IStringLocalizer<RubrumAbpGraphqlFluentValidationResource>>();
        
        foreach (var rule in rules)
        {
            var list = result.GetOrAdd(rule.PropertyName, _ => new List<string>());
            list.AddRange(rule.Components.Select(component => GetDescription(component.Validator, localizer)));
        }

        return result;
    }

    private static string GetDescription(
        IPropertyValidator validator, 
        IStringLocalizer<RubrumAbpGraphqlFluentValidationResource> localizer)
    {
        return validator switch {
            IExactLengthValidator v => localizer["Validator:ExactLength", v.Max],
            IMaximumLengthValidator v => localizer["Validator:MaximumLength",v.Max],
            IMinimumLengthValidator v => localizer["Validator:MinimumLength", v.Min],
            ILengthValidator v => localizer["Validator:Length", v.Min, v.Max],
            INullValidator => localizer["Validator:Null"],
            INotNullValidator => localizer["Validator:NotNull"],
            INotEmptyValidator => localizer["Validator:NotEmpty"],
            IInclusiveBetweenValidator v => localizer["Validator:InclusiveBetween", v.From, v.To],
            IBetweenValidator v => localizer["Validator:Between", v.From, v.To],
            IEqualValidator v => localizer["Validator:Equal", v.ValueToCompare],
            IGreaterThanOrEqualValidator v => localizer["Validator:GreaterThanOrEqual", v.ValueToCompare],
            ILessThanOrEqualValidator v => localizer["Validator:LessThanOrEqual", v.ValueToCompare],
            IComparisonValidator v => localizer["Validator:Comparison", v.ValueToCompare],
            IEmailValidator => localizer["Validator:Email"],
            IRegularExpressionValidator v => localizer["Validator:RegularExpression", v.Expression],
            _ => ""
        };
    }

    private static void AddValidatorType(ArgumentDefinition argument, Type type)
    {
        argument.ContextData.Add(WellKnownContextData.Validator, type);
    }

    private static void AddMiddleware(ObjectFieldDefinition field)
    {
        var middleware = new FieldMiddlewareDefinition(
            FieldClassMiddlewareFactory.Create<ValidationMiddleware>(),
            false,
            ValidationMiddleware.MiddlewareIdentifier);

        field.MiddlewareDefinitions.AddLast(middleware);
    }
}