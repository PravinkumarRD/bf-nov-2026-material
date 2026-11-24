using eCommerce.Application.Contracts;
using eCommerce.Dal;
using eCommerce.Domain;
using eCommerce.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure;

public class CommonQueriesRepository : ICommonQueriesRepository
{
    private readonly ECommerceDbContext _dbContext;

    public CommonQueriesRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<YourCartVm>> GetAllCartItemsAsync(int cartId)
    {
        var YourCartItems = from cart in _dbContext.Carts
                            join
                            cartItem in _dbContext.CartItems
                            on cart.CartId equals cartItem.CartId
                            join
                            product in _dbContext.Products
                            on cartItem.ProductId equals product.ProductId
                            join
                            catgeory in _dbContext.Categories
                            on product.CategoryId equals catgeory.CategoryId
                            where cart.CartId == cartId
                            select new YourCartVm
                            {
                                CartId = cartId,
                                CategoryName = catgeory.CategoryName,
                                ProductName = product.ProductName,
                                Price = product.UnitPrice,
                                Discount = product.Discount,
                                Quantity = cartItem.Quantity,
                                Size = cartItem.Size,
                                Picture = product.Picture
                            };
        return await YourCartItems.ToListAsync();
    }
}
