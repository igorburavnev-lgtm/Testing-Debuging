using System.Linq;

namespace Practise;

public static class TextTools
{
    public static int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Split(new[] { ' ', '\t', '\n', '\r' },
                          StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string Truncate(string text, int maxLength)
    {
        if (text.Length <= maxLength) return text;
        if (maxLength <= 3) return text.Substring(0, maxLength);
        return text.Substring(0, maxLength - 3) + "...";
    }

    public static string Capitalize(string word)
    {
        if (string.IsNullOrEmpty(word)) return word;
        return char.ToUpper(word[0]) + word.Substring(1).ToLower();
    }

    public static bool IsPalindrome(string text)
    {
        if (text is null) return false;
        string s = string.Concat(text.ToLower().Where(c => !char.IsWhiteSpace(c)));
        for (int i = 0; i < s.Length / 2; i++)
            if (s[i] != s[s.Length - 1 - i]) return false;
        return true;
    }

    public static string MaskCard(string digits)
    {
        if (digits.Length <= 4) return digits;
        return new string('*', digits.Length - 4) + digits.Substring(digits.Length - 4);
    }

    public static string RepeatJoin(string word, int times, string separator)
    {
        if (times <= 0) return "";
        var parts = new string[times];
        for (int i = 0; i < times; i++) parts[i] = word;
        return string.Join(separator, parts);
    }
}