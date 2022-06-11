using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Dtos.Customer;
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
  public ActionResult<List<CustomerResponseDto>> GetCustomers()
  {
    var customer = _customerService.GetCustomers();
    return Ok(customer);
  }

  [HttpGet("{id:int}")]
  public ActionResult<CustomerResponseDto> GetCustomer([FromRoute] int id)
  {
    var customer = _customerService.GetCustomer(id);

    if (customer is null)
      return NotFound();

    return Ok(customer);
  }

  [HttpPost]
  public ActionResult<CustomerResponseDto> PostCustomer([FromBody] CustomerCreateUpdateDto c)
  {
    var customer = _customerService.PostCustomer(c);

    return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, customer);
  }

  [HttpPut("{id:int}")]
  public ActionResult<CustomerResponseDto> PutCustomer([FromRoute] int id, [FromBody] CustomerCreateUpdateDto c)
  {
    var customer = _customerService.PutCustomer(id, c);

    if (customer is null)
      return NotFound();

    return Ok(customer);
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteCustomer([FromRoute] int id)
  {
    try
    {
      _customerService.DeleteCustomer(id);
      return NoContent();
    }
    catch (Exception)
    {
      return NotFound();
    }
  }
}
