namespace DebugPractise;

public static class Scenario6
{
    public static void Run()
    {
        List<string> names = LoadNames();

        int total = 0;
        int index = 0;

        foreach (string name in names)
        {
            total += name?.Length ?? 0;
            index++;
        }

        Console.WriteLine($"Суммарная длина: {total}");
    }

    private static List<string> LoadNames()
    {
        var names = new List<string>();
        for (int i = 0; i < 500; i++) names.Add("имя" + i);
        names[387] = null!;
        return names;
    }
}