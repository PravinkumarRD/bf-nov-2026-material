using eCommerce.Application.Contracts;
using eCommerce.Domain;

namespace eCommerce.Application.Services;

public class CartsService
{
    private readonly ICommonRepository<Cart> _cartRepository;

    public CartsService(ICommonRepository<Cart> cartRepository)
    {
        _cartRepository = cartRepository;
    }
    public async Task<Cart> GetCartDetailsAsync(int cartId)
    {
        return await _cartRepository.GetByIdAsync(cartId);
    }
    public async Task<int> CreateNewCart(Cart cart)
    {
        return await _cartRepository.AddAsync(cart);
    }
}
