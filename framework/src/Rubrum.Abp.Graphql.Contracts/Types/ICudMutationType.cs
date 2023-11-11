using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public interface ICudMutationType<TEntityDto, TKey, in TCreateInput, in TUpdateInput, in TService> :
    ICreateMutationType<TEntityDto, TKey, TCreateInput, TService>,
    IUpdateMutationType<TEntityDto, TKey, TUpdateInput, TService>,
    IDeleteMutationType<TEntityDto, TKey, TService>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TEntityDto, TKey, TCreateInput, TUpdateInput>,
    IDeleteGraphqlService<TEntityDto, TKey>
{
}

public interface ICudMutationType<TEntityDto, TKey, in TCreateInput, in TService> :
    ICudMutationType<TEntityDto, TKey, TCreateInput, TCreateInput, TService>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TEntityDto, TKey, TCreateInput>,
    IDeleteGraphqlService<TEntityDto, TKey>
{
}

public interface ICudMutationType<TEntityDto, TKey, in TService> :
    ICudMutationType<TEntityDto, TKey, TEntityDto, TService>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TEntityDto, TKey, TEntityDto>, IDeleteGraphqlService<TEntityDto, TKey>
{
}