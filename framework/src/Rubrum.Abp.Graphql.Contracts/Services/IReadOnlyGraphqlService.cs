using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface IReadOnlyGraphqlService<TEntityDto, in TKey> : IGraphqlService
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    Task<IQueryable<TEntityDto>> GetQueryableAsync();
}