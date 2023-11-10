using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface ICreateUpdateGraphqlService<TEntityDto, TKey, in TCreateUpdateInput, in TUpdateInput> :
    ICreateGraphqlService<TEntityDto, TKey, TCreateUpdateInput>,
    IUpdateGraphqlService<TEntityDto, TKey, TUpdateInput>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}

public interface ICreateUpdateGraphqlService<TEntityDto, TKey, in TCreateUpdateInput>
    : ICreateUpdateGraphqlService<TEntityDto, TKey, TCreateUpdateInput, TCreateUpdateInput>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}

public interface ICreateUpdateGraphqlService<TEntityDto, TKey>
    : ICreateUpdateGraphqlService<TEntityDto, TKey, TEntityDto, TEntityDto>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}