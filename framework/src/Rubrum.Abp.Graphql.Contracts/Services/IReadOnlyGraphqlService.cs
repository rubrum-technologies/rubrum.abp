using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface IReadOnlyGraphqlService<TEntityDto, in TKey>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    Task<TEntityDto> GetByIdAsync(TKey id);

    Task<IQueryable<TEntityDto>> GetQueryableAsync();
}