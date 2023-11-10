using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using HotChocolate.Configuration;
using HotChocolate.Resolvers;
using HotChocolate.Types.Descriptors.Definitions;
using Rubrum.Abp.Graphql.Validation;

namespace Rubrum.Abp.Graphql.Interceptors;

public class ValidationTypeInterceptor : TypeInterceptor
{
    public override void OnAfterCompleteName(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        if (definition is InputObjectTypeDefinition inputObjectType)
        {
            foreach (var field in inputObjectType.Fields)
            {
                var property = field.Property;

                if (property is null)
                {
                    return;
                }

                var attrs = GetValidationAttributes(property);

                AddDescriptionField(field, attrs);
            }
        }
    }

    public override void OnBeforeCompleteType(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        if (definition is not ObjectTypeDefinition def)
        {
            return;
        }

        foreach (var field in def.Fields)
        {
            foreach (var argument in field.Arguments)
            {
                if (argument.Parameter is null)
                {
                    continue;
                }

                field.MiddlewareDefinitions.AddLast(new FieldMiddlewareDefinition(
                    FieldClassMiddlewareFactory.Create<ValidationMiddleware>(),
                    false,
                    ValidationMiddleware.MiddlewareIdentifier));
            }
        }
    }

    private static void AddDescriptionField(InputFieldDefinition field, IEnumerable<ValidationAttribute> attrs)
    {
        var description = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(field.Description))
        {
            description.Append(field.Description);
        }

        foreach (var attr in attrs)
        {
            if (attr is RequiredAttribute)
            {
                description.Append("\n\rRequired");
            }

            if (attr is MinLengthAttribute minLength)
            {
                description.Append("\n\rMin Length: " + minLength.Length);
            }

            if (attr is MaxLengthAttribute maxLength)
            {
                description.Append("\n\rMax Length: " + maxLength.Length);
            }

            if (attr is StringLengthAttribute stringLength)
            {
                if (stringLength.MinimumLength > 0)
                {
                    description.Append("\n\rMin Length: " + stringLength.MinimumLength);
                }

                description.Append("\n\rMax Length: " + stringLength.MaximumLength);
            }

            if (attr is RangeAttribute range)
            {
                description.Append($"\n\rRange from {range.Minimum} to {range.Maximum}");
            }
        }

        field.Description = description.ToString();
    }

    private static IEnumerable<ValidationAttribute> GetValidationAttributes(PropertyInfo property)
    {
        return property.GetCustomAttributes(typeof(ValidationAttribute), true)
            .OfType<ValidationAttribute>();
    }
}
