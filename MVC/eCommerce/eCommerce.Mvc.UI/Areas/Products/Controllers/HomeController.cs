using eCommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Mvc.UI.Areas.Products.Controllers;

[Area("Products")]
public class HomeController : Controller
{
    private readonly ProductsService _productsService;

    public HomeController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productsService.GetAllProductsAsync();
        return View(products);
    }
    public async Task<IActionResult> Details(int id)
    {
        var product = await _productsService.GetProductDetailsAsync(id);
        return View(product);
    }
    public async Task<IActionResult> CatWiseProducts(int id)
    {
        var products = (await _productsService.GetAllProductsAsync()).Where(p => p.CategoryId == id);
        return View("Index",products.ToList());
    }
}
