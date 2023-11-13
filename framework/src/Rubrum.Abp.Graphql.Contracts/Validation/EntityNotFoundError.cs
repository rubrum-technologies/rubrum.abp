using Volo.Abp.Domain.Entities;

namespace Rubrum.Abp.Graphql.Validation;

public class EntityNotFoundError
{
    public EntityNotFoundError(EntityNotFoundException exception)
    {
        Id = exception.Id?.ToString();
        Type = exception.EntityType?.Name;
        Message = exception.Message;
    }

    public string? Id { get; }
    public string? Type { get; }
    public string Message { get; }
}