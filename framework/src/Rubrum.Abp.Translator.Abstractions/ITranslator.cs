namespace Rubrum.Abp.Translator;

public interface ITranslator
{
    Task<TranslateProcessResult> TranslateAsync(
        string into,
        string text,
        CancellationToken cancellationToken = default);

    Task<TranslateProcessResult> TranslateAsync(
        string from,
        string into,
        string text,
        CancellationToken cancellationToken = default);
}
