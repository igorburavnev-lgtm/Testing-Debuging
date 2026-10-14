namespace DebugPractise;

public static class Scenario4
{
    public struct Cell
    {
        public int Value;
    }

    public static void Run()
    {
        var board = new Cell[9];

        Console.WriteLine($"Массив создан, длина {board.Length}. Заполняем...");

        for (int i = 0; i < board.Length; i++)
        {
            board[i].Value = i + 1;
        }

        Console.WriteLine("Готово: " + string.Join(" ", board.Select(c => c.Value)));
    }
}