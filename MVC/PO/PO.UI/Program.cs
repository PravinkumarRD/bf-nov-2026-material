using Microsoft.EntityFrameworkCore;
using PO.Application.Contracts;
using PO.Application.Services;
using PO.Dal;
using PO.Entites;
using PO.Repository;

namespace PO.UI;

internal class Program
{
    static async Task Main(string[] args)
    {
        //Test Environment
        //ICommonRepository<Customer> customerMock = new CrudMock<Customer>();
        //CustomerService customerService = new CustomerService(customerMock);
        //await customerMock.InsertAsync(new Customer() { CustomerId = 100, ContactName = "Pravinkumar R. D.", City = "Pune" });
        //List<Customer> mockCustomers=await customerMock.GetAllAsync();
        //foreach (var customer in mockCustomers)
        //{
        //    Console.WriteLine($"Customer Name {customer.ContactName} lives in city {customer.City}!");
        //}

        PoDbContext poDbContext = new PoDbContext();

        ICommonRepository<Customer> customerRepo = new CommonRepository<Customer>(poDbContext);
        CustomerService customerServiceDb = new CustomerService(customerRepo);
        //Insert
        //int result = await customerServiceDb.RegisterCustomer(new Customer()
        //{
        //    ContactName="Pravin R. d.",
        //    Address="Suncity",
        //    City="Pune",
        //    IsActive=true,
        //    CreatedBy="Admin",
        //    CreatedOn=DateTime.Now,
        //    JoiningDate=DateTime.Now
        //});
        //var customers = await customerServiceDb.GetAllCustomersAsync();
        //foreach (var customer in customers)
        //{
        //    Console.WriteLine($"Customer Name {customer.ContactName} lives in city {customer.City}!");
        //}
        //Select Single
        //var customer = await customerServiceDb.GetCustomerDetailsAsync(1);
        var existingCustomer = new Customer()
        {
            CustomerId=1,
            ContactName = "Pravinkumar R. D.",
            Address = "Mooncity",
            City = "Bangalore",
            IsActive = true,
            CreatedBy = "Admin",
            CreatedOn = DateTime.Now,
            JoiningDate = DateTime.Now
        };
        var result = await customerServiceDb.ModifyCustomer(existingCustomer);
        var customer = await customerServiceDb.GetCustomerDetailsAsync(1);
    }
}
public class CrudMock<T> : ICommonRepository<T> where T : class
{
    private readonly List<T> _mockDb;
    public CrudMock()
    {
        _mockDb = new List<T>();
    }
    public async Task<List<T>> GetAllAsync()
    {
        return _mockDb.ToList();
    }

    public Task<T> GetDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task InsertAsync(T item)
    {
        _mockDb.Add(item);
    }

    public Task UpdateAsync(T item)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(T item)
    {
        throw new NotImplementedException();
    }
    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}