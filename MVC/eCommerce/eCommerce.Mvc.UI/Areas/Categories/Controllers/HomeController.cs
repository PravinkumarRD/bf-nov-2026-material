using eCommerce.Application.Services;
using eCommerce.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace eCommerce.Mvc.UI.Areas.Categories.Controllers;

[Area("Categories")]
public class HomeController : Controller
{
    private readonly CategoriesService _categoriesService;
    private readonly IMemoryCache _memoryCache;
    public HomeController(CategoriesService categoriesService, IMemoryCache memoryCache)
    {
        _categoriesService = categoriesService;
        _memoryCache = memoryCache;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["PageTitle"] = "Bajaj Categories List!";
        IEnumerable<Category> categories = _memoryCache.Get("CategoriesCache") as IEnumerable<Category>;
        if (categories == null)
        {
            var cats = await _categoriesService.GetAllCategoriesAsync();
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(45),
                SlidingExpiration = new TimeSpan(0, 5, 0)
            };
            _memoryCache.Set("CategoriesCache", cats, options);
            categories = cats;
        }
        return View(categories);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (ModelState.IsValid)
        {
            int result = await _categoriesService.RegisterNewCategory(category);
            if (result>0)
            {
                _memoryCache.Remove("CategoriesCache");
                return RedirectToAction("Index");
            }
        }
        return View();
    }
}
