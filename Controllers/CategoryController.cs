using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Dtos.Category;
using VendasTamboril.Services;

namespace VendasTamboril.Controllers;

[ApiController]
[Route("/categories")]
public class CategoryController : ControllerBase
{
  private readonly CategoryService _categoryService;

  public CategoryController([FromServices] CategoryService categoryService)
  {
    _categoryService = categoryService;
  }

  [HttpGet]
  public ActionResult<CategoryResponseDto> GetCategories()
  {
    var category = _categoryService.GetCategories();
    return Ok(category);
  }
}
