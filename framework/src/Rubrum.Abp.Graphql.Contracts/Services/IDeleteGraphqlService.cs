using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface IDeleteGraphqlService<TEntityDto, in TKey> : IGraphqlService
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    Task<TEntityDto> DeleteAsync(TKey id);
}