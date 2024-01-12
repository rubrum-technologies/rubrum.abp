using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.Ddd.HumanFriendly;

public interface IHumanFriendlyAppService<TEntityDto, TKey> : IApplicationService
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    Task<TEntityDto> GetByHumanIdAsync(long id);
}
