using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageManager : DomainService
{
    private readonly IReadOnlyRepository<Language, string> _repository;
    private readonly ICancellationTokenProvider _cancellationTokenProvider;

    public LanguageManager(
        IReadOnlyRepository<Language, string> repository,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        _repository = repository;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task<Language> CreateAsync(string id, string name)
    {
        await CheckNameAsync(name);

        return new Language(id, name);
    }

    public async Task ChangeNameAsync(Language language, string name)
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
            throw new LanguageNameAlreadyExistsException(name);
        }
    }
}
