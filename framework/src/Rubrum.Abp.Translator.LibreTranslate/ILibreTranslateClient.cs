namespace Rubrum.Abp.Translator;

public interface ILibreTranslateClient
{
    Task<ICollection<SupportedLanguage>> GetLanguagesAsync(CancellationToken cancellationToken = default);

    Task<TranslatedText> TranslateAsync(
        string q,
        string source,
        string target,
        CancellationToken cancellationToken = default);
}
