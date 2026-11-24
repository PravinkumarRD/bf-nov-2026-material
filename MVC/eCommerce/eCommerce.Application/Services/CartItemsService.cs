using eCommerce.Application.Contracts;
using eCommerce.Domain;
using System.ComponentModel;

namespace eCommerce.Application.Services;

public class CartItemsService
{
    private readonly ICommonRepository<CartItem> _cartItemRepository;

    public CartItemsService(ICommonRepository<CartItem> cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task<IEnumerable<CartItem>> GetCartItemsByCartId(int cartId)
    {
        return (await _cartItemRepository.GetAllAsync()).Where(ci => ci.CartId == cartId);
    }
    public async Task<int> AddNewCartItem(CartItem cartItem)
    {
        return await _cartItemRepository.AddAsync(cartItem);
    }
    public async Task<int> RemoveCartItem(int cartItemId)
    {
        return await _cartItemRepository.DeleteAsync(cartItemId);
    }
}
