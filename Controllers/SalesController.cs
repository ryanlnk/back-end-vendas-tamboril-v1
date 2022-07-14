using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Dtos.Sales;
using VendasTamboril.Services;

namespace VendasTamboril.Controllers;


[ApiController]
[Route("/sales")]
public class SalesController : ControllerBase
{
  private readonly SalesService _salesService;

  public SalesController([FromServices] SalesService salesService)
  {
    _salesService = salesService;
  }

  [HttpGet]
  public ActionResult<SalesResponseDto> GetSales()
  {
    var sales = _salesService.GetSales();
    return Ok(sales);
  }

  [HttpGet("{id:int}")]
  public ActionResult<SalesResponseDto> GetSale([FromRoute] int id)
  {
    var sale = _salesService.GetSale(id);

    if (sale is null)
      return NotFound();

    return Ok(sale);
  }

  [HttpPost]
  public ActionResult<SalesResponseDto> PostProduct([FromBody] SalesCreateDto s)
  {
    var sale = _salesService.PostSale(s);
    return CreatedAtAction(nameof(GetSales), new { id = sale.Id }, sale);
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteSale([FromRoute] int id)
  {
    try
    {
      _salesService.DeleteSale(id);
      return NoContent();
    }
    catch { return NotFound(); }
  }
}