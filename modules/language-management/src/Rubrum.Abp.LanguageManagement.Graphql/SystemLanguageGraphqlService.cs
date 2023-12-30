using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageGraphqlService(
    IRepository<SystemLanguage, string> repository,
    SystemLanguageManager manager,
    ISystemLanguageMapper mapper,
    ICancellationTokenProvider cancellationTokenProvider)
    : SystemLanguageAppService(repository, manager, mapper, cancellationTokenProvider), ISystemLanguageGraphqlService
{
    public async Task<IQueryable<SystemLanguageDto>> GetQueryableAsync()
    {
        return (await Repository.GetQueryableAsync()).Select(Mapper.Expression);
    }
}
