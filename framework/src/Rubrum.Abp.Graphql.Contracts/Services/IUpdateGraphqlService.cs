using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface IUpdateGraphqlService<TEntityDto, TKey, in TUpdateInput> : IGraphqlService
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    Task<TEntityDto> UpdateAsync(TUpdateInput input);
}