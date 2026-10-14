namespace DebugPractise;

public static class Scenario1
{
    public struct Player
    {
        public string Name;
        public int Score;
    }

    public static void Run()
    {
        var players = new Player[]
        {
            new Player { Name = "Аня",  Score = 0 },
            new Player { Name = "Боря", Score = 0 },
            new Player { Name = "Вера", Score = 0 },
        };

        for (int i = 0; i < players.Length; i++)
        {
            players[i].Score += 10;
        }

        Console.WriteLine("Ожидалось:  Аня 10, Боря 10, Вера 10");
        Console.Write("Получилось: ");
        foreach (var p in players) Console.Write($"{p.Name} {p.Score}, ");
        Console.WriteLine();
    }
}