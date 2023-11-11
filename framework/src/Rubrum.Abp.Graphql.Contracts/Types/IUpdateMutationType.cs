using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public interface IUpdateMutationType<TEntityDto, TKey, in TUpdateInput, in TService> : IGraphqlType
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : IUpdateGraphqlService<TEntityDto, TKey, TUpdateInput>
{
    Task<TEntityDto> UpdateAsync(TUpdateInput input, TService service);
}

public interface IUpdateMutationType<TEntityDto, TKey, in TService> :
    IUpdateMutationType<TEntityDto, TKey, TEntityDto, TService>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : IUpdateGraphqlService<TEntityDto, TKey, TEntityDto>
{
}