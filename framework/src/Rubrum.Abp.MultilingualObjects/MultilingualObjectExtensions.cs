using System.Globalization;
using Volo.Abp;

namespace Rubrum.Abp.MultilingualObjects;

public static class MultilingualObjectExtensions
{
    public static TTranslation? FindTranslation<TTranslation>(
        this IMultilingualObject<TTranslation> obj,
        string? culture = null)
        where TTranslation : IObjectTranslation
    {
        Check.NotNull(obj, nameof(obj));

        culture ??= CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        var translation = obj.Translations.FirstOrDefault(x => x.Language == culture) ??
                          obj.Translations.FirstOrDefault(x => x.Language == LanguageDefault.Culture);

        return translation;
    }

    public static TTranslation GetTranslation<TTranslation>(
        this IMultilingualObject<TTranslation> obj,
        string? culture = null)
        where TTranslation : IObjectTranslation
    {
        var translation = FindTranslation(obj, culture);

        return translation ?? throw new InvalidOperationException();
    }
}
