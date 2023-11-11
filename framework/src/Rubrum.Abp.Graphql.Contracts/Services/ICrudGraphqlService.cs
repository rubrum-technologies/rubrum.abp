using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Services;

public interface ICrudGraphqlService<TEntityDto, TKey, in TCreateInput, in TUpdateInput> :
    IReadOnlyGraphqlService<TEntityDto, TKey>,
    ICreateUpdateGraphqlService<TEntityDto, TKey, TCreateInput, TUpdateInput>,
    IDeleteGraphqlService<TEntityDto,TKey>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}

public interface ICrudGraphqlService<TEntityDto, TKey, in TCreateInput>
    : ICrudGraphqlService<TEntityDto, TKey, TCreateInput, TCreateInput>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}

public interface ICrudGraphqlService<TEntityDto, TKey>
    : ICrudGraphqlService<TEntityDto, TKey, TEntityDto>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}