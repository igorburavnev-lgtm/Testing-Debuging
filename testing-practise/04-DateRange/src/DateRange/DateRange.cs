namespace Practise;

public static class DateRange
{
    public static int Days(DateOnly from, DateOnly to)
    {
        if (to < from) throw new ArgumentException("конец раньше начала");
        return to.DayNumber - from.DayNumber + 1;
    }

    public static bool Overlaps(DateOnly aFrom, DateOnly aTo, DateOnly bFrom, DateOnly bTo)
    {
        return aFrom <= bTo && bFrom <= aTo;
    }

    public static int WorkDays(DateOnly from, DateOnly to)
    {
        int count = 0;
        for (var d = from; d <= to; d = d.AddDays(1))
            if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                count++;
        return count;
    }

    public static int Age(DateOnly birth, DateOnly today)
    {
        int age = today.Year - birth.Year;
        if (today < birth.AddYears(age)) age--;
        return age;
    }

    public static bool IsLeap(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }

    public static DateOnly NextMonday(DateOnly date)
    {
        var d = date.AddDays(1);
        while (d.DayOfWeek != DayOfWeek.Monday) d = d.AddDays(1);
        return d;
    }

    public static string Format(DateOnly from, DateOnly to)
    {
        string a = from.ToString("dd.MM.yyyy");
        string b = to.ToString("dd.MM.yyyy");
        if (a == b) return a;
        return a + " - " + b;
    }
}