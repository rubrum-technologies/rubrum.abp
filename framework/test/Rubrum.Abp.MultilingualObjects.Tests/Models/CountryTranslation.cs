namespace Rubrum.Abp.MultilingualObjects.Models;

public class CountryTranslation : IObjectTranslation
{
    public CountryTranslation(string language, string name)
    {
        Language = language;
        Name = name;
    }

    public string Language { get; }

    public string Name { get; }
}
