using Microsoft.AspNetCore.Mvc;
using PO.Application.Services;
using PO.Models;

namespace PO.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(CustomersService _customersService) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Customer>>> Get()
    {
        var customers = await _customersService.GetAllCustomers();
        if (customers.Count > 0)
        {
            return Ok(customers);
        }
        else
        {
            return NoContent();
        }
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Customer>> Get(int id)
    {
        var customer = await _customersService.GetCustomerDetails(id);
        if (customer != null)
        {
            return Ok(customer);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Customer>> Post(Customer customer)
    {
        if (ModelState.IsValid)
        {
            int result = await _customersService.RegisterNewCustomer(customer);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { id = customer.CustomerId }, customer);
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Customer Registration Failed! Please retry!"
                });
            }
        }
        return BadRequest(new
        {
            Message = "Please check you model for one or more validation issues!"
        });
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Customer>> Put(Customer customer)
    {
        if (ModelState.IsValid)
        {
            int result = await _customersService.ModifyCustomer(customer);
            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Customer Update Failed! Please retry!"
                });
            }
        }
        return BadRequest(new
        {
            Message = "Please check you model for one or more validation issues!"
        });
    }
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{customerId:int}")]
    public async Task<ActionResult<Customer>> Delete(int customerId)
    {
        int result = await _customersService.RemoveCustomer(customerId);
        if (result > 0)
        {
            return NoContent();
        }
        else
        {
            return BadRequest(new
            {
                Message = "Customer Delete Failed! Please retry!"
            });
        }

    }
}
