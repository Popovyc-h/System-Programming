namespace ChildApp;

using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        string path = args[0];
        string word = args[1];

        string text = File.ReadAllText(path);
        string[] words = text.Split(' ', '\n', '\r', '\t');
        int count = words.Count(w => w == word);

        Console.WriteLine($"Слово '{word}' знайдено {count} разів");
    }
}
