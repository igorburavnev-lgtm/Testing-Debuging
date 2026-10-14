using Practise;

namespace GradeBook.Tests;

public class GradeBookTests
{
    [Fact]
    public void CountAbove_ThreeGrades_CountsStrictlyAbove()
    {
        var grades = new List<int> { 3, 4, 5 };
        Assert.Equal(2, Practise.GradeBook.CountAbove(grades, 3));
    }

    [Theory]
    [InlineData(5, "A")]
    [InlineData(4, "B")]
    [InlineData(3, "C")]
    [InlineData(2, "F")]
    [InlineData(1, "F")]
    public void Letter_AllGrades(int grade, string expected)
    {
        Assert.Equal(expected, Practise.GradeBook.Letter(grade));
    }

    [Fact]
    public void Letter_OutOfRange_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Practise.GradeBook.Letter(6));
    }

    [Fact]
    public void Average_TwoGrades_ReturnsFraction()
    {
        var grades = new List<int> { 4, 5 };
        Assert.Equal(4.5, Practise.GradeBook.Average(grades));
    }

    [Fact]
    public void Average_SingleGrade_ReturnsItAsDouble()
    {
        var grades = new List<int> { 5 };
        Assert.Equal(5.0, Practise.GradeBook.Average(grades));
    }

    [Fact]
    public void Average_EmptyList_ThrowsArgumentException()
    {
        var grades = new List<int>();
        Assert.Throws<ArgumentException>(() => Practise.GradeBook.Average(grades));
    }

    [Fact]
    public void Max_PositiveGrades_ReturnsLargest()
    {
        var grades = new List<int> { 3, 5, 4 };
        Assert.Equal(5, Practise.GradeBook.Max(grades));
    }

    [Fact]
    public void Max_AllNegative_ReturnsLargest()
    {
        var grades = new List<int> { -5, -2, -9 };
        Assert.Equal(-2, Practise.GradeBook.Max(grades));
    }

    [Fact]
    public void Max_EmptyList_ThrowsArgumentException()
    {
        var grades = new List<int>();
        Assert.Throws<ArgumentException>(() => Practise.GradeBook.Max(grades));
    }

    [Fact]
    public void Median_OddCount_ReturnsMiddle()
    {
        var grades = new List<int> { 5, 1, 3 };
        Assert.Equal(3.0, Practise.GradeBook.Median(grades));
    }

    [Fact]
    public void Median_EvenCount_ReturnsMeanOfTwoMiddles()
    {
        var grades = new List<int> { 4, 1, 2, 3 };
        Assert.Equal(2.5, Practise.GradeBook.Median(grades));
    }

    [Fact]
    public void Median_DoesNotModifyInput()
    {
        var grades = new List<int> { 5, 1, 3 };
        Practise.GradeBook.Median(grades);
        Assert.Equal(new[] { 5, 1, 3 }, grades);
    }

    [Fact]
    public void Median_EmptyList_ThrowsArgumentException()
    {
        var grades = new List<int>();
        Assert.Throws<ArgumentException>(() => Practise.GradeBook.Median(grades));
    }

    [Fact]
    public void TopN_TwoOfThree_ReturnsTopTwoDescending()
    {
        var grades = new List<int> { 3, 5, 4 };
        Assert.Equal(new[] { 5, 4 }, Practise.GradeBook.TopN(grades, 2));
    }

    [Fact]
    public void TopN_MoreThanCount_ReturnsAll()
    {
        var grades = new List<int> { 3 };
        Assert.Equal(new[] { 3 }, Practise.GradeBook.TopN(grades, 5));
    }

    [Fact]
    public void TopN_Zero_ReturnsEmpty()
    {
        var grades = new List<int> { 3, 5 };
        Assert.Empty(Practise.GradeBook.TopN(grades, 0));
    }

    [Fact]
    public void TopN_DoesNotModifyInput()
    {
        var grades = new List<int> { 3, 5, 4 };
        Practise.GradeBook.TopN(grades, 2);
        Assert.Equal(new[] { 3, 5, 4 }, grades);
    }
}