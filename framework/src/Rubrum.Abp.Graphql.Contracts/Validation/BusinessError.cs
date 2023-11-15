using Volo.Abp;

namespace Rubrum.Abp.Graphql.Validation;

public class BusinessError
{
    public BusinessError(BusinessException exception)
    {
        Code = exception.Code;
        Details = exception.Details;
        Message = exception.Message.ReplaceNewLine() ?? string.Empty;
    }

    public string? Code { get; }

    public string? Details { get; }

    public string Message { get; }
}
