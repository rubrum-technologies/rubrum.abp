namespace Rubrum.Abp;

public static class StringExtensions
{
    public static string? ReplaceNewLine(this string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return text;
        }

        return text
            .Replace("\r\n", "\n")
            .Replace("\r", "\n");
    }

    public static string ToLowerFirstChar(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var firstChar = char.ToLower(input[0]);

        if (input.Length == 1)
        {
            return firstChar.ToString();
        }

        return firstChar + input[1..];
    }
}
