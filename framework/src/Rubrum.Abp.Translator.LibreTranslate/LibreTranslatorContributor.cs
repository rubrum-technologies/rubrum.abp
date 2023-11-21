using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Translator;

public class LibreTranslatorContributor : ITranslatorContributor, ITransientDependency
{
    private readonly ILibreTranslateClient _client;
    private readonly ILogger<LibreTranslatorContributor> _logger;

    public LibreTranslatorContributor(ILibreTranslateClient client, ILogger<LibreTranslatorContributor> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<TranslateProcessResult> TryTranslateAsync(
        string into,
        string text,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (!(await CheckSupportLanguageAsync("auto", into)))
            {
                return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
            }

            var result = await _client.TranslateAsync(text, "auto", into, cancellationToken);
            return new TranslateProcessResult(result.Text, TranslateProcessState.Done);
        }
        catch (Exception ex)
        {
            _logger.LogException(ex);
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
            if (!(await CheckSupportLanguageAsync(from, into)))
            {
                return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
            }

            var result = await _client.TranslateAsync(text, from, into, cancellationToken);
            return new TranslateProcessResult(result.Text, TranslateProcessState.Done);
        }
        catch (Exception ex)
        {
            _logger.LogException(ex);
            return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
        }
    }

    protected virtual async Task<bool> CheckSupportLanguageAsync(string from, string into)
    {
        var languages = await _client.GetLanguagesAsync();
        var language = languages.FirstOrDefault(x => x.Code == into);

        if (language is null)
        {
            return false;
        }

        return from == "auto" || language.Targets.Any(target => target == from);
    }
}
