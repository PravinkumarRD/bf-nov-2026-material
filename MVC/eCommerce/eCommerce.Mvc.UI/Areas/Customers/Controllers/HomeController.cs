using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Mvc.UI.Areas.Customers.Controllers;

[Area("Customers")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
