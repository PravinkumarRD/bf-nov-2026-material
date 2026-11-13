namespace DictionaryExample;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Strongly Typed Collection - Dictionary Example!");
        Dictionary<int,string> dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "One");
        dictionary.Add(2, "Two");
        dictionary.Add(3, "Three");
        dictionary.Add(4, "Four");

        foreach (var item in dictionary.Keys)
        {
            Console.WriteLine(dictionary[item]);
        }
    }
}
