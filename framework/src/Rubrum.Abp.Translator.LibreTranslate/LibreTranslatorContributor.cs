using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Translator;

public class LibreTranslatorContributor(
    ILibreTranslateClient client,
    IDistributedCache<ICollection<SupportedLanguage>> supportedLanguagesCache,
    ILogger<LibreTranslatorContributor> logger)
    : ITranslatorContributor, ITransientDependency
{
    public async Task<TranslateProcessResult> TryTranslateAsync(
        string into,
        string text,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (!await CheckSupportLanguageAsync("auto", into))
            {
                return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
            }

            var result = await client.TranslateAsync(text, "auto", into, cancellationToken);
            return new TranslateProcessResult(result.Text, TranslateProcessState.Done);
        }
        catch (Exception ex)
        {
            logger.LogException(ex);
            return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
        }
    }

    public async Task<TranslateProcessResult> TryTranslateAsync(
        string from,
        string into,
        string text,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (!await CheckSupportLanguageAsync(from, into))
            {
                return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
            }

            var result = await client.TranslateAsync(text, from, into, cancellationToken);
            return new TranslateProcessResult(result.Text, TranslateProcessState.Done);
        }
        catch (Exception ex)
        {
            logger.LogException(ex);
            return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
        }
    }

    protected virtual async Task<bool> CheckSupportLanguageAsync(string from, string into)
    {
        var languages = await supportedLanguagesCache.GetOrAddAsync(
            GetSupportedLanguagesCacheKey(),
            async () => await GetSupportedLanguagesAsync(),
            () => new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            },
            true) ?? new List<SupportedLanguage>();
        var language = languages.FirstOrDefault(x => x.Code == into);

        if (language is null)
        {
            return false;
        }

        return from == "auto" || language.Targets.Contains(from);
    }

    protected virtual string GetSupportedLanguagesCacheKey()
    {
        return "Rubrum.Abp.Translator.LibreTranslate.SupportedLanguages";
    }

    private async Task<ICollection<SupportedLanguage>> GetSupportedLanguagesAsync()
    {
        return await client.GetLanguagesAsync();
    }
}
