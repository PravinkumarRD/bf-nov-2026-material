using FirstAPIExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPIExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly List<Customer> _customers;
    public CustomersController()
    {
        _customers = new List<Customer>()
        {
            //new(){CustomerId=1001, ContactName="John Mark", City="London"},
            //new(){CustomerId=1002, ContactName="Manish Sharma", City="Pune"},
            //new(){CustomerId=1003, ContactName="Alisha C.", City="Mumbai"},
            //new(){CustomerId=1004, ContactName="Anjala Mathue", City="Berlin"},
        };
    }
    /*[HttpGet]
    public List<Customer> GetAll()
    {
        return _customers;
    }
    [HttpGet("{id:int}")]
    public Customer GetDetails(int id)
    {
        return _customers.Find(c => c.CustomerId == id);
    }*/

    /*[ProducesResponseType(StatusCodes.Status200OK,Type =typeof(List<Customer>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public IActionResult Get()
    {
        if (_customers.Count>0)
        {
            return Ok(_customers);
        }
        else
        {
            return NoContent();
        }
    }*/
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public ActionResult<List<Customer>> Get()
    {
        if (_customers.Count > 0)
        {
            return Ok(_customers);
        }
        else
        {
            return NoContent();
        }
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{id:int}")]
    public ActionResult<Customer> GetDetails(int id)
    {
        var customer =  _customers.Find(c => c.CustomerId == id);
        if (customer != null)
        {
            return Ok(customer);
        }
        else
        {
            return NoContent();
        }
    }
}
