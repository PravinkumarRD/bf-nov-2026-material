using System.Xml.Linq;

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
        //var finalResult = from customer in GetAllCustomer()
        //                  group customer by customer.City into customerGroup
        //                  select new
        //                  {
        //                      City = customerGroup.Key,
        //                      Count = customerGroup.Count()
        //                  };
        //foreach (var res in finalResult)
        //{
        //    Console.WriteLine($"In City {res.City} there are {res.Count} customers.");
        //}
        //var query1 = from customer in GetAllCustomer()
        //             select customer;
        //var query1 = from customer in GetAllCustomer()
        //             where customer.City == "New York"
        //             select customer;
        var query1 = from customer in GetAllCustomer()
                     orderby customer.City descending, customer.ContactName
                     select customer;
        foreach (var item in query1)
        {
            Console.WriteLine($"Customer Id {item.CustomerId}, Contact Name {item.ContactName} and city is {item.City}!");
        }
        Console.WriteLine();
        var query2 = from order in GetAllOrders()
                     select order;
        foreach (var item in query2)
        {
            Console.WriteLine($"Order Id {item.OrderId}, Order Date {item.OrderDate}, Required Date {item.RequiredDate} and placed by {item.CustomerId}!");
        }
        Console.WriteLine();
        var CustomersOrders = from customer in GetAllCustomer()
                              join
                              order in GetAllOrders()
                              on customer.CustomerId equals order.CustomerId
                              join
                              orderItem in GetAllOrderItems()
                              on order.OrderId equals orderItem.OrderId
                              join
                              product in GetAllProducts()
                              on orderItem.ProductId equals product.ProductId
                              select new 
                              {
                                  CustomerName=customer.ContactName,
                                  ShipCity=customer.City,
                                  OrderDate=order.OrderDate,
                                  ShipDate=order.RequiredDate,
                                  ProductName= product.ProductName,
                                  ActualPrice=product.Price,
                                  SellingPrice=product.Price- (product.Price * product.Discount / 100),
                                  PayableAmount= product.Price - (product.Price * product.Discount / 100) * orderItem.Quantity
                              };
        foreach (var co in CustomersOrders)
        {
            Console.WriteLine($"Customer {co.CustomerName} has placed the order on {co.OrderDate} which needs to be shipped on {co.ShipDate} to city {co.ShipCity}! Product Name is {co.ProductName} with actual Price {co.ActualPrice} and Selling Price {co.SellingPrice} and Payable Amount {co.PayableAmount}!");
        }
        var query3 = GetAllCustomer().Where(c => c.City == "New York");
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
    private static List<Order> GetAllOrders()
    {
        return new List<Order>()
        {
            new Order(){OrderId=101,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),CustomerId=2},
            new Order(){OrderId=102,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(3),CustomerId=2},
            new Order(){OrderId=103,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),CustomerId=5},
            new Order(){OrderId=103,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),CustomerId=5},
            new Order(){OrderId=104,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),CustomerId=4},
            new Order(){OrderId=105,OrderDate=DateTime.Now,RequiredDate=DateTime.Now.AddDays(2),CustomerId=4},
        };
    }
    private static IEnumerable<Product> GetAllProducts() 
    {
        var products = from xmlProduct in XElement.Load(@"D:\WebxTraining\Bajaj CDAC Nov 2026\C#\ProblemAndAnswer\ProblemStatement\Products.xml").Elements()
                       select new Product
                       {
                           ProductId=Convert.ToInt32( xmlProduct.Attribute("ProductId").Value),
                           ProductName = xmlProduct.Attribute("ProductName").Value,
                           Price = Convert.ToDouble(xmlProduct.Attribute("Price").Value),
                           Discount = Convert.ToInt32(xmlProduct.Attribute("Discount").Value)
                       };
        return products;
    }
    private static List<OrderItem> GetAllOrderItems()
    {
        return new List<OrderItem>()
        {
            new OrderItem(){ItemId=1,Quantity=2,ProductId=1001,OrderId=101},
            new OrderItem(){ItemId=2,Quantity=3,ProductId=1002,OrderId=101},
            new OrderItem(){ItemId=3,Quantity=1,ProductId=1003,OrderId=102},
            new OrderItem(){ItemId=4,Quantity=5,ProductId=1004,OrderId=103},
            new OrderItem(){ItemId=5,Quantity=2,ProductId=1005,OrderId=104},
        };
    }
}
