using eCommerce.Application.Contracts;
using eCommerce.Domain;

namespace eCommerce.Application.Services;

public class CategoriesService
{
    private readonly ICommonRepository<Category> _categoriesRepository;

    public CategoriesService(ICommonRepository<Category> categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _categoriesRepository.GetAllAsync();
    }
    public async Task<Category> GetCategoryDetailsAsync(int productId)
    {
        return await _categoriesRepository.GetByIdAsync(productId);
    }
    public async Task<int> RegisterNewCategory(Category category)
    {
        return await _categoriesRepository.AddAsync(category);
    }
}
