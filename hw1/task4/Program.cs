namespace ConsoleApp3;

using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\popov\Desktop\C#\ConsoleApp3\file.txt";
        string word = "bicycle";

        ProcessStartInfo info = new ProcessStartInfo
        {
            FileName = @"C:\Users\popov\Desktop\C#\ChildApp\bin\Debug\net10.0\ChildApp.exe",
            UseShellExecute = false,
            Arguments = $"\"{path}\" {word}"
        };

        Process process = new Process()
        {
            StartInfo = info
        };

        process.Start();
        process.WaitForExit();
    }
}
