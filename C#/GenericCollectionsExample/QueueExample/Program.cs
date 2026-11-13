namespace QueueExample;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Strongly Typed Collection - Queue Example!");
        Queue<int> tickets=new Queue<int>();
        tickets.Enqueue(1);
        tickets.Enqueue(2);
        tickets.Enqueue(3);
        tickets.Enqueue(4);
        //Console.WriteLine(tickets.Dequeue());
        Console.WriteLine(tickets.Peek());
        Console.WriteLine();
        foreach (var item in tickets)
        {
            Console.WriteLine(item);
        }
    }
}
