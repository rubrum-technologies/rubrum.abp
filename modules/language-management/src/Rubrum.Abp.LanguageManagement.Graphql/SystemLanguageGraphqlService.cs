using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageGraphqlService : SystemLanguageAppService, ISystemLanguageGraphqlService
{
    public SystemLanguageGraphqlService(
        IRepository<SystemLanguage, string> repository,
        SystemLanguageManager manager,
        ISystemLanguageMapper mapper,
        ICancellationTokenProvider cancellationTokenProvider) : base(repository,
        manager,
        mapper,
        cancellationTokenProvider)
    {
    }

    public async Task<IQueryable<SystemLanguageDto>> GetQueryableAsync()
    {
        return (await Repository.GetQueryableAsync()).Select(Mapper.Expression);
    }
}
