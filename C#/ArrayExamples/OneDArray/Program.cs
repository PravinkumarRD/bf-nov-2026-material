namespace OneDArray;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1-D Array Example!");
        int[] numbers = new int[] {10 ,20, 30, 40, 50 };
        Console.WriteLine("Elements of the array:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
        Console.WriteLine();
        string[] names = new string[3];
        names[0] = "Alice";
        names[1] = "Bob";
        names[2] = "Charlie";
        Console.WriteLine("Elements of the names array:");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(names[i]);
        }
        Console.WriteLine();
        Order[] orders = new Order[2];
        orders[0] = new Order { OrderId = 1, OrderDate = DateTime.Now, Quantity = 5 };
        orders[1] = new Order { OrderId = 2, OrderDate = DateTime.Now, Quantity = 10 };
        for (int i = 0; i < orders.Length; i++)
        {
            Console.WriteLine($"Order ID: {orders[i].OrderId}, Date: {orders[i].OrderDate}, Quantity: {orders[i].Quantity}");
        }
    }
}
