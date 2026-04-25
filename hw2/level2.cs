namespace GoldMiningMineLevel2;

internal class Program
{
    // НАША СПІЛЬНА СКРИНЯ (Спільний стан)
    static int TotalGold = 0;

    static void Main()
    {
        Thread[] miners = new Thread[10];

        for (int i = 0; i < 10; i++)
        {
            miners[i] = new Thread(AddGold);
            miners[i].Start();
        }

        // Чекаємо всіх
        foreach (var miner in miners) miner.Join();

        Console.WriteLine($"Очікувалось золота: 1000000");
        Console.WriteLine($"Фактично у скрині:  {TotalGold}");
        // Студент має написати коментар: "Гроші зникли через проблему Lost Update, бо операція TotalGold++ не є атомарною (Читання-Модифікація-Запис)."
    }

    static void AddGold()
    {
        for (int i = 0; i < 100000; i++)
        {
            // ВАШ КОД ТУТ: Просто збільште TotalGold на 1 (без жодної синхронізації)
            TotalGold++;
        }
    }
}

/*
Потоки читають старе значення тобто обидва прочитали одне й те саме наприклад два потоки додають одночасно 
перший додав лічильник в нас вже 1 і другий теж додає але він ще не побвчив що наш лічильник не 0 а 1 тому 
він знову до 0 додав 1 замість того щоб лічильник був 2 він в нас 1 
*/
