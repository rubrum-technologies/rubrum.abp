using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace Rubrum.Abp.Translator;

public class Translator : ITranslator, ITransientDependency
{
    protected readonly IEnumerable<ITranslatorContributor> TranslatorContributors;
    protected readonly ICancellationTokenProvider CancellationTokenProvider;

    public Translator(
        IEnumerable<ITranslatorContributor> translatorContributors,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        TranslatorContributors = translatorContributors;
        CancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task<TranslateProcessResult> TranslateAsync(
        string into,
        string text,
        CancellationToken cancellationToken = default)
    {
        foreach (var translatorContributor in TranslatorContributors)
        {
            var result = await translatorContributor.TryTranslateAsync(
                into,
                text,
                CancellationTokenProvider.FallbackToProvider(cancellationToken));
            
            if (result.State == TranslateProcessState.Unsupported)
            {
                continue;
            }

            return result;
        }

        return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
    }

    public async Task<TranslateProcessResult> TranslateAsync(
        string from,
        string into,
        string text,
        CancellationToken cancellationToken = default)
    {
        foreach (var translatorContributor in TranslatorContributors)
        {
            var result = await translatorContributor.TryTranslateAsync(
                from,
                into,
                text,
                CancellationTokenProvider.FallbackToProvider(cancellationToken));

            if (result.State == TranslateProcessState.Unsupported)
            {
                continue;
            }

            return result;
        }

        return new TranslateProcessResult(text, TranslateProcessState.Unsupported);
    }
}
