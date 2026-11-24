using Microsoft.AspNetCore.Mvc;
using FirstMvcApp.Models;
using FirstMvcApp.Models.VM;

namespace FirstMvcApp.Controllers;

public class EmployeesController : Controller
{
    private readonly List<Employee> _employees;
    private readonly List<Customer> _customers;
    public EmployeesController()
    {
        _employees = new()
        {
            new Employee(){EmployeeId=1001, EmployeeName="Manish Sharma",City="Delhi"},
            new Employee(){EmployeeId=1002, EmployeeName="Alisha C.",City="Pune"},
            new Employee(){EmployeeId=1003, EmployeeName="Manisha Kaushik",City="Bangalore"},
            new Employee(){EmployeeId=1004, EmployeeName="Yash P. C.",City="Pune"},
        };
        _customers = new()
        {
            new Customer(){CustomerId=100, ContactName="Manish Sharma",City="Delhi"},
            new Customer(){CustomerId=100, ContactName="Alisha C.",City="Pune"},
            new Customer(){CustomerId=100, ContactName="Manisha Kaushik",City="Bangalore"},
            new Customer(){CustomerId=100, ContactName="Yash P. C.",City="Pune"},
        };
    }
    public ContentResult Index()
    {
        return Content("<h1>Welcome To Bajaj Finserv!</h1><hr/><h6>A Core Development Center! Pune!</h6>", "text/html");
    }
    public FileResult File()
    {
        return File("~/css/site.css", "text/css");
    }
    public JsonResult Data()
    {
        return Json(_employees);
    }
    public ViewResult Office()
    {
        return View();
    }
    public IActionResult List()
    {
        if(ModelState.IsValid)
        //ViewBag.PageTitle = "Welcome To Bajaj Employees List!";
        //ViewBag.PageSubTitle = "Core Development Members of ODC! Pune!";
        //ViewData["PageTitle"]= "Welcome To Bajaj Employees List!";
        //ViewData["PageSubTitle"] = "Core Development Members of ODC! Hyderabad!";
        TempData["PageTitle"] = "Welcome To Bajaj Employees List!";
        TempData["PageSubTitle"] = "Core Development Members of ODC! Hyderabad!";

        return View(_employees);
    }
    public IActionResult Chennai()
    {
        ViewBag.One = "This is ViewBag Object!";
        ViewData["Two"] = "This is ViewData Object!";
        TempData["Three"] = "This is TempData Object!";
        return RedirectToAction("Bangalore");
    }
    public IActionResult Bangalore()
    {
        return View();
    }
    public IActionResult EmployeesCustomers()
    {
        CustomerEmployeeVM customerEmployeeVM = new CustomerEmployeeVM()
        {
            Customers = _customers,
            Employees = _employees
        };
        return View(customerEmployeeVM);
    }
}
