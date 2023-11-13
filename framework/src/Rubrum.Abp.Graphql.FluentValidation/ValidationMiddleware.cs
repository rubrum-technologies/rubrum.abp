using System.ComponentModel.DataAnnotations;
using FluentValidation;
using HotChocolate.Resolvers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Validation;

namespace Rubrum.Abp.Graphql;

internal class ValidationMiddleware
{
    public const string MiddlewareIdentifier = "Rubrum.Abp.Graphql.FluentValidation.ValidationMiddleware";

    private readonly FieldDelegate _next;

    public ValidationMiddleware(FieldDelegate next)
    {
        _next = Check.NotNull(next, nameof(next));
    }

    public async Task InvokeAsync(IMiddlewareContext context)
    {
        var arguments = context.Selection.Field.Arguments;

        foreach (var argument in arguments)
        {
            var value = context.ArgumentValue<object?>(argument.Name);
            if (value == null)
            {
                continue;
            }

            if (!argument.ContextData.TryGetValue(WellKnownContextData.Validator, out var validatorType))
            {
                continue;
            }

            var validator = (IValidator)context.Services.GetRequiredService((Type)validatorType!);
            var validationContext = new ValidationContext<object>(value);
            var validationResult = await validator.ValidateAsync(
                validationContext,
                context.RequestAborted);

            if (validationResult is { IsValid: false })
            {
                throw new AbpValidationException(validationResult.Errors
                    .Select(x => new ValidationResult(x.ErrorMessage, new[] { x.PropertyName }))
                    .ToList());
            }
        }

        await _next(context).ConfigureAwait(false);
    }
}
