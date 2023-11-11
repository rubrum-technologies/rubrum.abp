using HotChocolate.Types;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace Rubrum.Abp.Graphql.Validation;

public class AbpErrorFactory :
    IPayloadErrorFactory<BusinessException, BusinessError>,
    IPayloadErrorFactory<EntityNotFoundException, EntityNotFoundError>,
    IPayloadErrorFactory<AbpValidationException, ValidationError>
{
    public BusinessError CreateErrorFrom(BusinessException exception)
    {
        return new BusinessError(exception);
    }

    public EntityNotFoundError CreateErrorFrom(EntityNotFoundException exception)
    {
        return new EntityNotFoundError(exception);
    }

    public ValidationError CreateErrorFrom(AbpValidationException exception)
    {
        return new ValidationError(exception);
    }
}