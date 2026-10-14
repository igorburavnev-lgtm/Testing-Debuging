namespace Practise;

public static class GradeBook
{
    public static double Average(List<int> grades)
    {
        if (grades.Count == 0) throw new ArgumentException("список пуст");
        int sum = 0;
        foreach (int g in grades) sum += g;
        return (double)sum / grades.Count;
    }

    public static int Max(List<int> grades)
    {
        if (grades.Count == 0) throw new ArgumentException("список пуст");
        int max = grades[0];
        foreach (int g in grades)
            if (g > max) max = g;
        return max;
    }

    public static double Median(List<int> grades)
    {
        if (grades.Count == 0) throw new ArgumentException("список пуст");
        var copy = new List<int>(grades);
        copy.Sort();
        int mid = copy.Count / 2;
        if (copy.Count % 2 == 1) return copy[mid];
        return (copy[mid] + copy[mid - 1]) / 2.0;
    }

    public static int CountAbove(List<int> grades, int threshold)
    {
        int count = 0;
        foreach (int g in grades)
            if (g > threshold) count++;
        return count;
    }

    public static List<int> TopN(List<int> grades, int n)
    {
        if (n <= 0) return new List<int>();
        var copy = new List<int>(grades);
        copy.Sort();
        copy.Reverse();
        return copy.GetRange(0, Math.Min(n, copy.Count));
    }

    public static string Letter(int grade)
    {
        if (grade < 1 || grade > 5) throw new ArgumentOutOfRangeException(nameof(grade));
        if (grade == 5) return "A";
        if (grade == 4) return "B";
        if (grade == 3) return "C";
        return "F";
    }
}