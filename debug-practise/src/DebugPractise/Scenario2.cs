namespace DebugPractise;

public static class Scenario2
{
    public struct Team
    {
        public string Name;
        public List<string> Members;
    }

    public static void Run()
    {
        var original = new Team
        {
            Name = "Альфа",
            Members = new List<string> { "Аня" },
        };

        Team copy = original;
        copy.Name = "Бета";
        copy.Members = new List<string>(original.Members);
        copy.Members.Add("Боря");

        Console.WriteLine($"Ожидалось:  Альфа — 1 человек, Бета — 2 человека");
        Console.WriteLine($"Получилось: {original.Name} — {original.Members.Count}, " +
                          $"{copy.Name} — {copy.Members.Count}");
        Console.WriteLine();
        Console.WriteLine($"  original.Members: {string.Join(", ", original.Members)}");
        Console.WriteLine($"  copy.Members:     {string.Join(", ", copy.Members)}");
    }
}