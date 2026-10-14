namespace DebugPractise;

public static class Scenario5
{
    public static void Run()
    {
        var readings = new List<int> { 1, -2, 3, -4, 5 };

        Console.WriteLine("Было: " + string.Join(", ", readings));

        for (int i = readings.Count - 1; i >= 0; i--)
        {
            if (readings[i] < 0) readings.RemoveAt(i);
        }

        Console.WriteLine("Стало: " + string.Join(", ", readings));
    }
}