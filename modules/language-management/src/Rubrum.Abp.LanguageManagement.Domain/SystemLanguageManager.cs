using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageManager : DomainService
{
    private readonly ICancellationTokenProvider _cancellationTokenProvider;
    private readonly IReadOnlyRepository<SystemLanguage, string> _repository;

    public SystemLanguageManager(
        IReadOnlyRepository<SystemLanguage, string> repository,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        _repository = repository;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task<SystemLanguage> CreateAsync(string id, string name)
    {
        await CheckNameAsync(name);

        return new SystemLanguage(id, name);
    }

    public async Task ChangeNameAsync(SystemLanguage language, string name)
    {
        if (language.Name == name)
        {
            return;
        }

        await CheckNameAsync(name);

        language.Name = name;
    }

    private async Task CheckNameAsync(string name)
    {
        var cancellationToken = _cancellationTokenProvider.Token;

        if (await _repository.AnyAsync(x => x.Name == name, cancellationToken))
        {
            throw new SystemLanguageNameAlreadyExistsException(name);
        }
    }
}
