namespace ConstructorExamples;

internal abstract class Person
{
    protected Person()
    {
        Console.WriteLine("Default Constructor Of Person Class.");
    }
    public string ContactName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

internal class Customer : Person
{
    static Customer()
    {
        Console.WriteLine("Static Constructor Of Customer Class.");
    }
    public Customer()
    {
        Console.WriteLine("Default Constructor Of Customer Class.");
    }
    public Customer(string contactName, string city, string state, int customerId):this()
    {
        Console.WriteLine("Parameterized Constructor Of Customer Class.");
        ContactName = contactName;
        City = city;
        State = state;
        CustomerId = customerId;
    }
    public Customer(Customer customer)
    {
        Console.WriteLine("Copy Constructor Of Customer Class.");
        ContactName = customer.ContactName;
        City = customer.City;
        State = customer.State;
        CustomerId = customer.CustomerId;
    }
    public int CustomerId { get; set; }
}