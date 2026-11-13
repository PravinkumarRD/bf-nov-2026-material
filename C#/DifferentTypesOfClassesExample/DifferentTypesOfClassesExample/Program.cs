using BajajMath;

namespace DifferentTypesOfClassesExample;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Class Types along with Inheritance!!");
        //Person <= Customer <= PrimeCustomer
        //PrimeCustomer primeCustomer = new PrimeCustomer();
        Parent parent = new Parent();
        AdvanceMath advanceMath = new AdvanceMath();
        //Console.WriteLine(Counter.Count);
        //Counter.IncrementCount();
        //Counter.IncrementCount();
        //Counter.IncrementCount();
        //Console.WriteLine(Counter.Count);
        //Order o1 = new Order();
        //Console.WriteLine(o1.GetOrderId());
        //Order o2 = new Order();
        //Console.WriteLine(o2.GetOrderId());
        //Order o3 = new Order();
        //Console.WriteLine(o3.GetOrderId());

        
        //Object Initializer
        Customer customer = new Customer()
        {
            CustomerId=1001,
            SocialId = 123456789,
            FullName = "John Doe",
            Address = "123 Main St",
            City = "Anytown",
            State = "CA",
            Phone = "555-1234",
            Email = "john.doe@abc.com",
            Country = "USA"
        };
        Order order = new Order()
        {
            OrderId = 36773,
            OrderDate = DateTime.Now,
            RequiredDate = DateTime.Now.AddDays(7),
            CustomerId = customer.CustomerId
        };

        // Type Inference
        //Anonymous Type
        var CustomerOrder = new
        {
            CustId=customer.CustomerId,
            ContactName= customer.FullName,
            ContactNumber = customer.Phone,
            Oid = order.OrderId,
            DeliveryDate = order.RequiredDate
        };
        Console.WriteLine($"You need to deliver an order to {CustomerOrder.ContactName} whose contact number is {CustomerOrder.ContactNumber}, order number {CustomerOrder.Oid} by {CustomerOrder.DeliveryDate}!");

        //var - Can not be used as a parameter type, return type, field type, property type, or event type. It can only be used as a local variable type. It must be initialized at the time of declaration
    }
}

//class Order
//{
//    public Order()
//    {
//        Counter.IncrementCount();
//    }
//    public int GetOrderId()
//    {
//        return Counter.Count;
//    }
//}