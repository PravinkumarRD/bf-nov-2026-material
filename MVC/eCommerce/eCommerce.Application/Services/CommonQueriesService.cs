using eCommerce.Application.Contracts;
using eCommerce.Domain.ViewModels;

namespace eCommerce.Application.Services;

public class CommonQueriesService(ICommonQueriesRepository _commonQueriesRepository)
{
    public async Task<List<YourCartVm>> GetYourCartItemsAsync(int cartId)
    {
        return await _commonQueriesRepository.GetAllCartItemsAsync(cartId);
    }
}
