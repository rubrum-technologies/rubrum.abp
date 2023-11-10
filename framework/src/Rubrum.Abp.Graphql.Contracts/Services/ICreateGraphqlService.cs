using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface ICreateGraphqlService<TEntityDto, TKey, in TCreateInput> : IGraphqlService
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    Task<TEntityDto> CreateAsync(TCreateInput input);
}

public interface ICreateGraphqlService<TEntityDto, TKey> : ICreateGraphqlService<TEntityDto, TKey, TEntityDto>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}