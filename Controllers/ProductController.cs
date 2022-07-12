using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Dtos.Product;
using VendasTamboril.Services;

namespace VendasTamboril.Controllers;


[ApiController]
[Route("/products")]
public class ProductController : ControllerBase
{
  private readonly ProductService _productService;

  public ProductController([FromServices] ProductService productService)
  {
    _productService = productService;
  }

  [HttpGet]
  public ActionResult<ProductResponseDto> GetProducts()
  {
    var product = _productService.GetProducts();
    return Ok(product);
  }

  [HttpGet("{id:int}")]
  public ActionResult<ProductResponseDto> GetProduct([FromRoute] int id)
  {
    var product = _productService.GetProduct(id);

    if (product is null)
      return NotFound();

    return Ok(product);
  }

  [HttpPost]
  public ActionResult<ProductResponseDto> PostProduct([FromBody] ProductCreateUpdateDto c)
  {
    var product = _productService.PostProduct(c);
    return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
  }

  [HttpPut("{id:int}")]
  public ActionResult<ProductResponseDto> PutProduct([FromRoute] int id, [FromBody] ProductCreateUpdateDto c)
  {
    var product = _productService.PutProduct(id, c);

    if (product is null)
      return null;

    return Ok(product);
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteProduct([FromRoute] int id)
  {
    try
    {
      _productService.DeleteProduct(id);
      return NoContent();
    }
    catch { return NotFound(); }
  }
}