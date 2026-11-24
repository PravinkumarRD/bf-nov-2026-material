using eCommerce.Domain.ViewModels;

namespace eCommerce.Application.Contracts;

public interface ICommonQueriesRepository
{
    Task<List<YourCartVm>> GetAllCartItemsAsync(int cartId);
}
