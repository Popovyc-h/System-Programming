namespace GoldMiningMineLevel3;

internal class Program
{
    static int TotalGold = 0;

    // ВАШ КОД ТУТ: Оголосіть ThreadLocal<int> для локальних мішків шахтарів.
    static ThreadLocal<int> LocalSacks = new ThreadLocal<int>(() => 0);

    static void Main()
    {
        Thread[] miners = new Thread[10];

        for (int i = 0; i < 10; i++)
        {
            miners[i] = new Thread(AddGoldLocal);
            miners[i].Start();
        }

        foreach (var miner in miners) miner.Join();

        Console.WriteLine($"Фактично у скрині: {TotalGold} (Має бути рівно 1000000!)");

        // Обов'язково звільняємо пам'ять!
        LocalSacks.Dispose();
    }

    static void AddGoldLocal()
    {
        for (int i = 0; i < 100000; i++)
        {
            // ВАШ КОД ТУТ: Збільшуйте значення у локальному мішку (LocalSacks.Value)
            LocalSacks.Value++;
        }

        // Після циклу (в кінці зміни), шахтар здає своє золото.
        // Використовуємо Interlocked.Add для безпечного додавання в спільну скриню
        // (це спойлер до наступних лекцій, але чудова точка переходу)
        Interlocked.Add(ref TotalGold, LocalSacks.Value);
    }
}
