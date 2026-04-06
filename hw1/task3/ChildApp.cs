namespace ChildApp;

internal class Program
{
    static void Main(string[] args)
    {
        int num1 = int.Parse(args[0]);
        int num2 = int.Parse(args[1]);
        string operation = args[2];

        Console.WriteLine($"Число 1: {num1}");
        Console.WriteLine($"Число 2: {num2}");
        Console.WriteLine($"Операція: {operation}");

        if (operation == "+")
            Console.WriteLine($"Результат: {num1 + num2}");
        else if (operation == "-")
            Console.WriteLine($"Результат: {num1 - num2}");
        else if (operation == "*")
            Console.WriteLine($"Результат: {num1 * num2}");
        else if (operation == "/")
            Console.WriteLine($"Результат: {num1 / num2}");
    }
}
