namespace Rubrum.Abp.Graphql.Validation;

public class ValidationError
{
    public ValidationError(Exception exception)
    {
        Message = exception.Message;
    }

    public string Message { get; }
}
