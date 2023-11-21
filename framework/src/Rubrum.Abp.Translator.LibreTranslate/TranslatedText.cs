using System.Text.Json.Serialization;

namespace Rubrum.Abp.Translator;

public class TranslatedText
{
    [JsonPropertyName("TranslatedText")]
    public required string Text { get; init; }
}
