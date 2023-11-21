using Microsoft.Extensions.Logging;
using Rubrum.Abp.Languages;
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
        Language into,
        string text,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _client.TranslateAsync(text, "auto", into.Value, cancellationToken);
            return new TranslateProcessResult(result.Text, TranslateProcessState.Done);
        }
        catch (Exception ex)
        {
            _logger.LogException(ex);
            return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
        }
    }

    public async Task<TranslateProcessResult> TryTranslateAsync(
        Language from,
        Language into,
        string text,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _client.TranslateAsync(text, from.Value, into.Value, cancellationToken);
            return new TranslateProcessResult(result.Text, TranslateProcessState.Done);
        }
        catch (Exception ex)
        {
            _logger.LogException(ex);
            return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
        }
    }
}
