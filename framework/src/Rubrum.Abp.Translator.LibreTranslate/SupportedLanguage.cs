namespace Rubrum.Abp.Translator;

public class SupportedLanguage
{
    public required string Code { get; init; }

    public required string Name { get; init; }

    public required List<string> Targets { get; init; }
}
