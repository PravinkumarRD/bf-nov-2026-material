namespace ListExample;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Strongly Typed Collection - List<T> Example!");
        List<int> numbers = new List<int>() { 100,200,300};
        numbers.Add(400);
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}
