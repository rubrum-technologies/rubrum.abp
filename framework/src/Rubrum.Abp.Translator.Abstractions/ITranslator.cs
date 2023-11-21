using Rubrum.Abp.Languages;

namespace Rubrum.Abp.Translator;

public interface ITranslator
{
    Task<TranslateProcessResult> TranslateAsync(
        Language into,
        string text,
        CancellationToken cancellationToken = default);

    Task<TranslateProcessResult> TranslateAsync(
        Language from,
        Language into,
        string text,
        CancellationToken cancellationToken = default);
}
