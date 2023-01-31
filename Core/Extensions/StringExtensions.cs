using System.Text.RegularExpressions;

namespace Core.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string arg)
    {
        var words = arg.Trim().Split(' ');
        arg = "";

        foreach (var word in words)
            arg += word[..1].ToUpper() + word[1..].ToLower() + " ";

        return arg.TrimEnd();
    }

    public static string ToEnglishCase(this string arg)
    {
        char[] turkishChars = { 'ç', 'ğ', 'ı', 'ö', 'ş', 'ü', 'Ç', 'Ğ', 'İ', 'Ö', 'Ş', 'Ü' },
               englishChars = { 'c', 'g', 'i', 'o', 's', 'u', 'C', 'G', 'I', 'O', 'S', 'U' };

        for (int i = 0; i < turkishChars.Length; i++)
            arg = arg.Replace(turkishChars[i], englishChars[i]);

        return arg;
    }

    public static string ToValueCase(this string arg)
    {
        return Regex.Replace(Regex.Replace(arg.ToLower().ToEnglishCase(), @"[^0-9a-zA-Z:\s]+", ""), @"\s+", " ")
                    .Replace(" ", "-")
                    .Trim();
    }
}