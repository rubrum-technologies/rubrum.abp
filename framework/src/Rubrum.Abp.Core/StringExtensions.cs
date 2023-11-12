namespace Rubrum.Abp;

public static class StringExtensions
{
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