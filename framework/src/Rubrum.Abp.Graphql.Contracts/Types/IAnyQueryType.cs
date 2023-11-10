using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public interface IAnyQueryType<TEntityDto, TKey, in TService> : IGraphqlType
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : IReadOnlyGraphqlService<TEntityDto, TKey>
{
    Task<IQueryable<TEntityDto>> AnyAsync(TService service);
}