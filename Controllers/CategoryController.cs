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

  [HttpGet("{id:int}")]
  public ActionResult<CategoryResponseDto> GetCategory([FromRoute] int id)
  {
    var category = _categoryService.GetCategory(id);

    if (category is null)
      return NotFound();

    return Ok(category);
  }

  [HttpPost]
  public ActionResult<CategoryResponseDto> PostCategory([FromBody] CategoryCreateUpdateDto c)
  {
    var category = _categoryService.PostCategory(c);
    return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
  }
}
