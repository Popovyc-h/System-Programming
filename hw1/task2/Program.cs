namespace ConsoleApp3;

using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = @"C:\Users\popov\Desktop\C#\ChildApp\bin\Debug\net10.0\ChildApp.exe";

        Process process = new Process();
        process.StartInfo = info;
        process.Start();

        Console.WriteLine("Що робити з дочірнім процесом?");
        Console.WriteLine("1 - Чекати завершення");
        Console.WriteLine("2 - Примусово завершити");
        Console.Write("Ваш вибір: ");
        string input = Console.ReadLine();

        if (input == "1")
        {
            process.WaitForExit();
            Console.WriteLine($"Дочірній процес завершився з кодом: {process.ExitCode}");
        }
        else if (input == "2")
        {
            process.Kill();
            Console.WriteLine("Дочірній процес примусово завершено!");
        }
    }
}
