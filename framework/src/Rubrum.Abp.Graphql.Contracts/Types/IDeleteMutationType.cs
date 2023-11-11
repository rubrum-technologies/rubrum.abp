using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public interface IDeleteMutationType<TEntityDto, in TKey, in TService> : IGraphqlType
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : IDeleteGraphqlService<TEntityDto, TKey>
{
    Task DeleteAsync(TKey id, TService service);
}