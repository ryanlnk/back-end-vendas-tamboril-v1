using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Models;
using VendasTamboril.Services;

namespace VendasTamboril.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
  private readonly CustomerService _customerService;

  public CustomerController([FromServices] CustomerService customerService)
  {
    _customerService = customerService;
  }

  [HttpGet]
  public ActionResult<List<Customer>> GetCustomers()
  {
    var customer = _customerService.GetCustomers();
    return Ok(customer);
  }

  [HttpGet("{id:int}")]
  public ActionResult<Customer> GetCustomer([FromRoute] int id)
  {
    Customer customer = _customerService.GetCustomer(id);

    if (customer is null)
      return NotFound();

    return Ok(customer);
  }

  [HttpPost]
  public ActionResult<Customer> PostCustomer([FromBody] Customer c)
  {
    var customer = _customerService.PostCustomer(c);

    return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, customer);
  }

  [HttpPut("{id:int}")]
  public ActionResult<Customer> PutCustomer([FromRoute] int id, [FromBody] Customer c)
  {
    var customer = _customerService.PutCustomer(id, c);

    if (customer is null)
      return NotFound();

    return Ok(customer);
  }
}
