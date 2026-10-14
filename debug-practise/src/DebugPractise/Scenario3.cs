namespace DebugPractise;

public static class Scenario3
{
    public struct Point
    {
        public int X;
        public int Y;
        public override string ToString() => $"({X}, {Y})";
    }

    public static void Run()
    {
        var map = new Dictionary<Point, string>();

        map[new Point { X = 1, Y = 2 }] = "дом";
        map[new Point { X = 5, Y = 7 }] = "школа";

        var looking = new Point { X = 1, Y = 2 };

        bool found = map.TryGetValue(looking, out string? name);

        Console.WriteLine($"В словаре записей: {map.Count}");
        foreach (var pair in map) Console.WriteLine($"  ключ {pair.Key} -> {pair.Value}");
        Console.WriteLine();
        Console.WriteLine($"Ищем {looking}");
        Console.WriteLine($"Ожидалось:  найдено = True, name = дом");
        Console.WriteLine($"Получилось: найдено = {found}, name = {name ?? "null"}");
    }
}