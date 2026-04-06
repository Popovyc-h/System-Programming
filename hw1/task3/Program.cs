namespace ConsoleApp3;

using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        ProcessStartInfo info = new ProcessStartInfo
        {
            FileName = @"C:\Users\popov\Desktop\C#\ChildApp\bin\Debug\net10.0\ChildApp.exe",
            UseShellExecute = false
        };


        Process process = new Process()
        {
            StartInfo = info
        };

        Console.Write("Enter first number: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int n2 = int.Parse(Console.ReadLine());
        Console.Write("Enter operation (+,-,*,/): ");
        string operation = Console.ReadLine();


        info.Arguments = $"{n1} {n2} {operation}";

        process.Start();
        process.WaitForExit();
        Console.WriteLine($"ExitCode: {process.ExitCode}");
    }
}
