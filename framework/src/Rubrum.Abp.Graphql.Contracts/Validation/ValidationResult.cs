namespace Rubrum.Abp.Graphql.Validation;

public class ValidationResult
{
    public ValidationResult(System.ComponentModel.DataAnnotations.ValidationResult result)
    {
        ErrorMessage = result.ErrorMessage;
    }

    public string? ErrorMessage { get; }
}
