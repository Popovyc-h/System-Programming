namespace GoldMiningMine;

internal class Program
{
    static void Main()
    {
        // 1. Створіть CancellationTokenSource
        var cts = new CancellationTokenSource();

        Thread miner = new Thread(() => DigForGold(cts.Token));
        miner.Name = "Шахтар Боб";

        Console.WriteLine($"[Менеджер] Стан до запуску: {miner.ThreadState}");
        miner.Start();

        // Менеджер перевіряє стан під час роботи
        Thread.Sleep(500);
        Console.WriteLine($"[Менеджер] Стан під час роботи: {miner.ThreadState}"); // Має бути WaitSleepJoin або Running

        // 2. Через 2 секунди менеджер натискає "сирену" (викликає Cancel)
        Thread.Sleep(2000);
        Console.WriteLine("[Менеджер] Сирена! Зміна закінчена.");
        // ВАШ КОД ТУТ: Викличте скасування
        cts.Cancel();
        // 3. Дочекайтеся завершення потоку (Join)
        // ВАШ КОД ТУТ:
        miner.Join();
        Console.WriteLine($"[Менеджер] Стан після завершення: {miner.ThreadState}"); // Має бути Stopped
    }

    static void DigForGold(CancellationToken token)
    {
        // ВАШ КОД ТУТ: Напишіть цикл while, який перевіряє, чи не було запиту на скасування (IsCancellationRequested)
        // Всередині циклу:
        // - Виводьте повідомлення "Копаю..."
        // - Засинайте на 300 мілісекунд (Thread.Sleep)
        while (!token.IsCancellationRequested)
        {
            Console.WriteLine("Копаю...");
            Thread.Sleep(300);
        }

        Console.WriteLine($"{Thread.CurrentThread.Name} безпечно зібрав речі і йде додому.");
    }
}
