using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface IUpdateGraphqlService<TEntityDto, in TKey, in TUpdateInput> : IGraphqlService
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    Task<TEntityDto> UpdateAsync(TKey id, TUpdateInput input);
}