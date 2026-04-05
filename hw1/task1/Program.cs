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
        process.WaitForExit();
        var exitCode = process.ExitCode;
        Console.WriteLine($"Дочірній процес завершився з кодом: {process.ExitCode}");
    }
}
