using PO.Application.Contracts;
using PO.Entites;

namespace PO.Application.Services;

public class CustomerService
{
    private readonly ICommonRepository<Customer> _customerRepository;

    public CustomerService(ICommonRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }
    public async Task<Customer> GetCustomerDetailsAsync(int customerId)
    {
        return await _customerRepository.GetDetailsAsync(customerId);
    }
    public async Task<int> RegisterCustomer(Customer customer)
    {
        await _customerRepository.InsertAsync(customer);
        return await _customerRepository.SaveChangesAsync();
    }
    public async Task<int> ModifyCustomer(Customer customer)
    {
        await _customerRepository.UpdateAsync(customer);
        return await _customerRepository.SaveChangesAsync();
    }
    public async Task<int> DeleteCustomer(Customer customer)
    {
        await _customerRepository.DeleteAsync(customer);
        return await _customerRepository.SaveChangesAsync();
    }
}
