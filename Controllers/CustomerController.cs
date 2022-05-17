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
  public ActionResult<List<Customer>> GetCustomer()
  {
    var customer = _customerService.GetCustomer();
    return Ok(customer);
  }

  [HttpPost]
  public ActionResult<Customer> PostCustomer([FromBody] Customer c)
  {
    var customer = _customerService.PostCustomer(c);

    return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
  }
}
