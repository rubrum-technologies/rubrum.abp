using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public interface IReadOnlyQueryType<TEntityDto, TKey, in TService> :
    IAnyQueryType<TEntityDto, TKey, TService>,
    ICountQueryType<TEntityDto, TKey, TService>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : IReadOnlyGraphqlService<TEntityDto, TKey>
{
    Task<TEntityDto> GetByIdAsync(TKey id, TService service);
    Task<IQueryable<TEntityDto>> GetAsync(TService service);
    Task<IQueryable<TEntityDto>> GetListAsync(TService service);
}