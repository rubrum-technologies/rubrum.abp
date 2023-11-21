using Rubrum.Abp.Languages;

namespace Rubrum.Abp.Translator;

public interface ITranslatorContributor
{
    Task<TranslateProcessResult> TryTranslateAsync(
        Language into,
        string text,
        CancellationToken cancellationToken = default);
    
    Task<TranslateProcessResult> TryTranslateAsync(
        Language from,
        Language into,
        string text,
        CancellationToken cancellationToken = default);
}
