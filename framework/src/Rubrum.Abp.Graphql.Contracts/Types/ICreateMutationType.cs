using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public interface ICreateMutationType<TGetOutputDto, TKey, in TCreateInput, in TService> : IGraphqlType
    where TKey : notnull
    where TGetOutputDto : IEntityDto<TKey>
    where TService : ICreateGraphqlService<TGetOutputDto, TKey, TCreateInput>
{
    Task<TGetOutputDto> CreateAsync(TCreateInput input, TService service);
}

public interface ICreateMutationType<TEntityDto, TKey, in TService> :
    ICreateMutationType<TEntityDto, TKey, TEntityDto, TService>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateGraphqlService<TEntityDto, TKey>
{
}