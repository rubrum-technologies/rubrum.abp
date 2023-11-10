using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public interface ICudMutationType<TGetOutputDto, TKey, in TCreateInput, in TUpdateInput, in TService> :
    ICreateMutationType<TGetOutputDto, TKey, TCreateInput, TService>,
    IUpdateMutationType<TGetOutputDto, TKey, TUpdateInput, TService>,
    IDeleteMutationType<TKey, TService>
    where TKey : notnull
    where TGetOutputDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TGetOutputDto, TKey, TCreateInput, TUpdateInput>,
    IDeleteGraphqlService<TKey>
{
}

public interface ICudMutationType<TGetOutputDto, TKey, in TCreateInput, in TService> :
    ICudMutationType<TGetOutputDto, TKey, TCreateInput, TCreateInput, TService>
    where TKey : notnull
    where TGetOutputDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TGetOutputDto, TKey, TCreateInput>, IDeleteGraphqlService<TKey>
{
}

public interface ICudMutationType<TEntityDto, TKey, in TService> :
    ICudMutationType<TEntityDto, TKey, TEntityDto, TService>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TEntityDto, TKey, TEntityDto>, IDeleteGraphqlService<TKey>
{
}