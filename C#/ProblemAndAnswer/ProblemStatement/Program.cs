namespace ProblemStatement;

class Result
{
    public int Count { get; set; }
    public string City { get; set; } = string.Empty;
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Problem Statement - Find total number of customers in each city!");
        //List<Result> finalResult = new List<Result>();
        //foreach (var customer in GetAllCustomer())
        //{
        //   Result? result=finalResult.Find(delegate(Result r) { return r.City == customer.City; });
        //    if (result == null)
        //    {
        //        result = new Result();
        //        result.City = customer.City;
        //        result.Count = 1;
        //        finalResult.Add(result);
        //    }
        //    else
        //    {
        //        result.Count++;
        //    }
        //}
        var finalResult = from customer in GetAllCustomer()
                          group customer by customer.City into customerGroup
                          select new
                          {
                              City = customerGroup.Key,
                              Count = customerGroup.Count()
                          };
        foreach (var res in finalResult)
        {
            Console.WriteLine($"In City {res.City} there are {res.Count} customers.");
        }
    }
    private static List<Customer> GetAllCustomer()
    {
        return new List<Customer>()
        {
            new Customer { CustomerId = 1, ContactName = "John Doe", City = "New York" },
            new Customer { CustomerId = 2, ContactName = "Jane Smith", City = "Los Angeles" },
            new Customer { CustomerId = 3, ContactName = "Bob Johnson", City = "Chicago" },
            new Customer { CustomerId = 4, ContactName = "Alice Brown", City = "New York" },
            new Customer { CustomerId = 5, ContactName = "Charlie Davis", City = "Chicago" }
        };
    }
}
