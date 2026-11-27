using PO.Application.Contracts;
using PO.Models;

namespace PO.Application.Services;

public class CustomersService
{
    private readonly ICommonRepository<Customer> _customerRepository;

    public CustomersService(ICommonRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _customerRepository.GetAllAsync();
    }
    public async Task<Customer> GetCustomerDetails(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }
    public async Task<int> RegisterNewCustomer(Customer customer)
    {
        return await _customerRepository.AddAsync(customer);
    }
    public async Task<int> ModifyCustomer(Customer customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }
    public async Task<int> RemoveCustomer(int id)
    {
        return await _customerRepository.DeleteAsync(id);
    }
}
