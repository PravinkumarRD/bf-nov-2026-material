namespace ConstructorExamples;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Constructor Examples!");
        //Customer customer = new Customer();
        Customer customer1 = new Customer("Pravinkumar R. D.","Pune", "Maharashtra", 101);
        Customer customer2 = new Customer(customer1);
        Console.WriteLine(customer2.ContactName);
    }
}
