using Ardalis.SmartEnum;

namespace Rubrum.Abp.Languages;

public class Language : SmartEnum<Language, string>
{
    public static readonly Language Russian = new("Русский", "ru");
    public static readonly Language English = new("English", "en");
    
    private Language(string name, string value) : base(name, value)
    {
    }
}
