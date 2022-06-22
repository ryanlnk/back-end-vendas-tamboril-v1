using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Dtos.Seller;
using VendasTamboril.Services;

namespace VendasTamboril.Controllers;

[ApiController]
[Route("sellers")]

public class SellerController : ControllerBase
{
  private readonly SellerService _sellerService;

  public SellerController([FromServices] SellerService sellerService)
  {
    _sellerService = sellerService;
  }

  [HttpGet]
  public ActionResult<List<SellerResponseDto>> GetSellers()
  {
    var seller = _sellerService.GetSellers();
    return Ok(seller);
  }

  [HttpGet("{id:int}")]
  public ActionResult<SellerResponseDto> GetSeller([FromRoute] int id)
  {
    var seller = _sellerService.GetSeller(id);

    if (seller is null)
      return NotFound();

    return Ok(seller);
  }

  [HttpPost]
  public ActionResult<SellerResponseDto> PostSellers([FromBody] SellerCreateUpdateDto c)
  {
    var seller = _sellerService.PostSeller(c);

    return CreatedAtAction(nameof(GetSellers), new { id = seller.Id }, seller);
  }

  [HttpPut("{id:int}")]
  public ActionResult<SellerResponseDto> PutSellers([FromRoute] int id, [FromBody] SellerCreateUpdateDto c)
  {
    var seller = _sellerService.PutSeller(id, c);

    if (seller is null)
      return NotFound();

    return Ok(seller);
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteSeller([FromRoute] int id)
  {
    try
    {
      _sellerService.DeleteSeller(id);
      return NoContent();
    }
    catch
    {
      return NotFound();
    }
  }
}

