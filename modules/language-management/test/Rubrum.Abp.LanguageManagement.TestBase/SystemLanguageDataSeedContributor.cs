using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Threading;
using static Rubrum.Abp.LanguageManagement.LanguageCodes;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    protected static readonly Dictionary<string, string> Languages = new()
    {
        { Arabic, "ا\u064eل\u0652ع\u064eر\u064eب\u0650ي\u064e\u0651ة\u064f" },
        { Chinese, "汉语" },
        { English, "English" },
        { French, "Français" },
        { German, "Deutsch" },
        { Hindi, "ह\u093fन\u094dद\u0940" },
        { Bengali, "ব\u09be\u0982ল\u09be" },
        { Italian, "Italiano" },
        { Japanese, "日本語" },
        { Korean, "한국어" },
        { Polish, "Polski" },
        { Portuguese, "Português" },
        { Russian, "Русский" }
    };

    private readonly ICancellationTokenProvider _cancellationTokenProvider;
    private readonly SystemLanguageManager _manager;

    private readonly IRepository<SystemLanguage, string> _repository;

    public SystemLanguageDataSeedContributor(
        IRepository<SystemLanguage, string> repository,
        SystemLanguageManager manager,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        _repository = repository;
        _manager = manager;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var cancellationToken = _cancellationTokenProvider.Token;

        if (await _repository.AnyAsync(cancellationToken))
        {
            return;
        }

        foreach (var (code, name) in Languages)
        {
            var language = await _manager.CreateAsync(code, name);
            await _repository.InsertAsync(language, true, cancellationToken);
        }
    }
}
