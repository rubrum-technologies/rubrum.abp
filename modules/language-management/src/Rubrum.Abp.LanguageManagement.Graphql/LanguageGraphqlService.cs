using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageGraphqlService : LanguageAppService, ILanguageGraphqlService
{
    public LanguageGraphqlService(
        IRepository<Language, string> repository,
        LanguageManager manager,
        ILanguageMapper mapper,
        ICancellationTokenProvider cancellationTokenProvider) : base(repository,
        manager,
        mapper,
        cancellationTokenProvider)
    {
    }

    public async Task<IQueryable<LanguageDto>> GetQueryableAsync()
    {
        return (await Repository.GetQueryableAsync()).Select(Mapper.Expression);
    }
}
