namespace Rubrum.Abp.Translator;

public interface ITranslatorContributor
{
    Task<TranslateProcessResult> TryTranslateAsync(
        string into,
        string text,
        CancellationToken cancellationToken = default);

    Task<TranslateProcessResult> TryTranslateAsync(
        string from,
        string into,
        string text,
        CancellationToken cancellationToken = default);
}
