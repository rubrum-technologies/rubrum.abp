using FluentValidation;
using FluentValidation.Validators;
using HotChocolate.Configuration;
using HotChocolate.Resolvers;
using HotChocolate.Types.Descriptors.Definitions;
using Rubrum.Abp.Graphql.Extensions;

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

        var descriptions = GetDescriptions(validator);

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

    private static Dictionary<string, List<string>> GetDescriptions(IValidator validator)
    {
        var result = new Dictionary<string, List<string>>();

        if (validator is not IEnumerable<IValidationRule> rules)
        {
            return result;
        }

        foreach (var rule in rules)
        {
            var list = result.GetOrAdd(rule.PropertyName, _ => new List<string>());
            list.AddRange(rule.Components.Select(component => GetDescription(component.Validator)));
        }

        return result;
    }

    private static string GetDescription(IPropertyValidator validator)
    {
        // TODO: Сделать через локализацию Abp
        return validator switch {
            IExactLengthValidator => "IExactLengthValidator",
            IMaximumLengthValidator => "IMaximumLengthValidator",
            IMinimumLengthValidator => "IMinimumLengthValidator",
            ILengthValidator => "ILengthValidator",
            INullValidator => "INullValidator",
            INotNullValidator => "INotNullValidator",
            INotEmptyValidator => "INotEmptyValidator",
            IInclusiveBetweenValidator => "IInclusiveBetweenValidator",
            IBetweenValidator => "IBetweenValidator",
            IEqualValidator => "IEqualValidator",
            IGreaterThanOrEqualValidator => "IGreaterThanOrEqualValidator",
            ILessThanOrEqualValidator => "ILessThanOrEqualValidator",
            IComparisonValidator => "IComparisonValidator",
            IEmailValidator => "IEmailValidator",
            IPredicateValidator => "IPredicateValidator",
            IRegularExpressionValidator => "IRegularExpressionValidator",
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