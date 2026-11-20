using Microsoft.AspNetCore.Mvc;
using PO.Application.Services;

namespace PO.Mvc.Web.UI.Controllers;

public class CustomersController : Controller
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["PageTitle"] = "Bajaj Customers List!";
        var customers = await _customerService.GetAllCustomersAsync();
        if (customers.Count>0)
        {
            return View(customers);
        }
        else
        {
            ViewData["ErrorMessage"] = "Customers Data Not Found!";
            return View();
        }
        
    }
}
