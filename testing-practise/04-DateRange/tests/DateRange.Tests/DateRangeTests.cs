using Practise;

namespace DateRange.Tests;

public class DateRangeTests
{
    private static DateOnly D(int day) => new DateOnly(2026, 3, day);

    [Fact]
    public void Format_DifferentDates_JoinsWithDash()
    {
        Assert.Equal("01.03.2026 - 05.03.2026",
            Practise.DateRange.Format(D(1), D(5)));
    }

    [Fact]
    public void NextMonday_FromMonday_GoesAWeekAhead()
    {
        Assert.Equal(D(9), Practise.DateRange.NextMonday(D(2)));
    }

    [Fact]
    public void Days_SameDay_ReturnsOne()
    {
        Assert.Equal(1, Practise.DateRange.Days(D(1), D(1)));
    }

    [Fact]
    public void Days_ThreeDays_ReturnsThree()
    {
        Assert.Equal(3, Practise.DateRange.Days(D(1), D(3)));
    }

    [Fact]
    public void Days_EndBeforeStart_Throws()
    {
        Assert.Throws<ArgumentException>(() => Practise.DateRange.Days(D(5), D(1)));
    }

    [Fact]
    public void Overlaps_TouchingOneDay_ReturnsTrue()
    {
        Assert.True(Practise.DateRange.Overlaps(D(1), D(5), D(5), D(9)));
    }

    [Fact]
    public void Overlaps_GapOfOneDay_ReturnsFalse()
    {
        Assert.False(Practise.DateRange.Overlaps(D(1), D(5), D(6), D(9)));
    }

    [Fact]
    public void Overlaps_OneInsideAnother_ReturnsTrue()
    {
        Assert.True(Practise.DateRange.Overlaps(D(1), D(10), D(3), D(5)));
    }

    [Fact]
    public void WorkDays_FullWeekMondayToSunday_ReturnsFive()
    {
        Assert.Equal(5, Practise.DateRange.WorkDays(D(2), D(8)));
    }

    [Fact]
    public void WorkDays_OnlySaturday_ReturnsZero()
    {
        Assert.Equal(0, Practise.DateRange.WorkDays(D(7), D(7)));
    }

    [Fact]
    public void WorkDays_OnlySunday_ReturnsZero()
    {
        Assert.Equal(0, Practise.DateRange.WorkDays(D(8), D(8)));
    }

    [Fact]
    public void Age_BeforeBirthdayThisYear_ReturnsPreviousAge()
    {
        var birth = new DateOnly(2000, 5, 10);
        var today = new DateOnly(2020, 5, 9);
        Assert.Equal(19, Practise.DateRange.Age(birth, today));
    }

    [Fact]
    public void Age_OnBirthday_AlreadyCounts()
    {
        var birth = new DateOnly(2000, 5, 10);
        var today = new DateOnly(2020, 5, 10);
        Assert.Equal(20, Practise.DateRange.Age(birth, today));
    }

    [Fact]
    public void Age_DayAfterBirthday_ReturnsFullYears()
    {
        var birth = new DateOnly(2000, 5, 10);
        var today = new DateOnly(2020, 5, 11);
        Assert.Equal(20, Practise.DateRange.Age(birth, today));
    }

    [Theory]
    [InlineData(2024, true)]
    [InlineData(2023, false)]
    [InlineData(1900, false)]
    [InlineData(2000, true)]
    public void IsLeap_KnownYears(int year, bool expected)
    {
        Assert.Equal(expected, Practise.DateRange.IsLeap(year));
    }
}