namespace StackExample;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Strongly Typed Collection - Stack Example!");
        Stack<string> books = new Stack<string>();
        books.Push("C# V-1");
        books.Push("C# V-2");
        books.Push("C# V-3");
        books.Push("C# V-4");
        //Console.WriteLine(books.Pop());
        Console.WriteLine(books.Peek());
        Console.WriteLine();
        foreach (var item in books)
        {
            Console.WriteLine(item);
        }
    }
}
