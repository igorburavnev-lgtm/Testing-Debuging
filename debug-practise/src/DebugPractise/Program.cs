using DebugPractise;

// Запуск:  dotnet run -- 1      (или 2, 3, 4, 5, 6)
// В VS Code: F5, номер спросят.

var scenarios = new (string Title, Action Run)[]
{
    ("Турнирная таблица: очки не начисляются",        Scenario1.Run),
    ("Копия команды: правки уходят не туда",          Scenario2.Run),
    ("Карта города: ключ есть, а не находится",       Scenario3.Run),
    ("Игровое поле: падает на первой же клетке",      Scenario4.Run),
    ("Чистка показаний: падает посреди цикла",        Scenario5.Run),
    ("Длина имён: падает на одной записи из 500",     Scenario6.Run),
};

if (args.Length == 0 || !int.TryParse(args[0], out int n) || n < 1 || n > scenarios.Length)
{
    Console.WriteLine("Отладка: практика\n");
    for (int i = 0; i < scenarios.Length; i++)
        Console.WriteLine($"  {i + 1}. {scenarios[i].Title}");
    Console.WriteLine("\nЗапуск:  dotnet run -- <номер>");
    Console.WriteLine("Задание и подсказки по каждому сценарию — в README.md");
    return;
}

var chosen = scenarios[n - 1];
Console.WriteLine($"=== Сценарий {n}: {chosen.Title} ===\n");
chosen.Run();
