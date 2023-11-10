using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;
using Volo.Abp.Domain.Entities;

namespace Rubrum.Abp.Graphql.Validation;

public class AbpErrorFactory :
    IPayloadErrorFactory<EntityNotFoundException, EntityNotFoundError>,
    IPayloadErrorFactory<ValidationException, ValidationError>
{
    public EntityNotFoundError CreateErrorFrom(EntityNotFoundException exception)
    {
        return new EntityNotFoundError(exception);
    }

    public ValidationError CreateErrorFrom(ValidationException exception)
    {
        return new ValidationError(exception);
    }
}
