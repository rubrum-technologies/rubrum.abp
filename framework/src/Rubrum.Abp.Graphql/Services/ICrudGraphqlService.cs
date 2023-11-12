using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.Graphql.Services;

public interface ICrudGraphqlService<TEntityDto, in TKey, in TCreateInput, in TUpdateInput> :
    IReadOnlyGraphqlService<TEntityDto, TKey>,
    ICreateUpdateAppService<TEntityDto, TKey, TCreateInput, TUpdateInput>,
    IDeleteAppService<TKey>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
}
