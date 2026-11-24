using eCommerce.Application.Contracts;
using eCommerce.Domain;

namespace eCommerce.Application.Services;

public class ProductsService
{
    private readonly ICommonRepository<Product> _productsRepository;

    public ProductsService(ICommonRepository<Product> productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productsRepository.GetAllAsync();
    }
    public async Task<Product> GetProductDetailsAsync(int productId)
    {
        return await _productsRepository.GetByIdAsync(productId);
    }
}
