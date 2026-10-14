using Practise;

namespace TextTools.Tests;

public class TextToolsTests
{
    [Fact]
    public void Capitalize_MixedCase_FirstUpperRestLower()
    {
        Assert.Equal("Иван", Practise.TextTools.Capitalize("иВАН"));
    }

    [Theory]
    [InlineData("ля", 3, "-", "ля-ля-ля")]
    [InlineData("ля", 1, "-", "ля")]
    [InlineData("ля", 0, "-", "")]
    public void RepeatJoin_Cases(string word, int times, string sep, string expected)
    {
        Assert.Equal(expected, Practise.TextTools.RepeatJoin(word, times, sep));
    }

    [Fact]
    public void CountWords_EmptyString_ReturnsZero()
    {
        Assert.Equal(0, Practise.TextTools.CountWords(""));
    }

    [Fact]
    public void CountWords_WhitespaceOnly_ReturnsZero()
    {
        Assert.Equal(0, Practise.TextTools.CountWords("   "));
    }

    [Fact]
    public void CountWords_DoubleSpaces_CountsTwo()
    {
        Assert.Equal(2, Practise.TextTools.CountWords("раз  два"));
    }

    [Fact]
    public void CountWords_TabAndNewline_AreSeparators()
    {
        Assert.Equal(3, Practise.TextTools.CountWords("раз\tдва\nтри"));
    }

    [Fact]
    public void Truncate_ShorterThanLimit_ReturnsAsIs()
    {
        Assert.Equal("абвгде", Practise.TextTools.Truncate("абвгде", 10));
    }

    [Fact]
    public void Truncate_ExactlyAtLimit_ReturnsAsIs()
    {
        Assert.Equal("абвгде", Practise.TextTools.Truncate("абвгде", 6));
    }

    [Fact]
    public void Truncate_LongerThanLimit_FitsInsideLimit()
    {
        string result = Practise.TextTools.Truncate("абвгде", 5);
        Assert.Equal("аб...", result);
        Assert.True(result.Length <= 5, $"длина результата {result.Length}, а предел 5");
    }

    [Fact]
    public void IsPalindrome_SimpleWord_ReturnsTrue()
    {
        Assert.True(Practise.TextTools.IsPalindrome("шалаш"));
    }

    [Fact]
    public void IsPalindrome_MixedCase_IgnoresCase()
    {
        Assert.True(Practise.TextTools.IsPalindrome("Шалаш"));
    }

    [Fact]
    public void IsPalindrome_WithSpaces_IgnoresSpaces()
    {
        Assert.True(Practise.TextTools.IsPalindrome("а роза упала на лапу азора"));
/// <summary>
/// Проверяет, является ли текст палиндромом, игнорируя пробелы.
/// </summary>
    }

    [Fact]
    public void IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        Assert.False(Practise.TextTools.IsPalindrome("абв"));
    }

    [Fact]
    public void MaskCard_LongNumber_HidesAllButLastFour()
    {
        Assert.Equal("************3456", Practise.TextTools.MaskCard("1234567890123456"));
    }

    [Fact]
    public void MaskCard_ExactlyFourDigits_ReturnsAsIs()
    {
        Assert.Equal("1234", Practise.TextTools.MaskCard("1234"));
    }

    [Fact]
    public void MaskCard_ShortNumber_ReturnsAsIs()
    {
        Assert.Equal("123", Practise.TextTools.MaskCard("123"));
    }
}