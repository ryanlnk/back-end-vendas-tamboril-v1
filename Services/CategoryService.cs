using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Category;

namespace VendasTamboril.Services;

public class CategoryService
{
  private readonly TamborilContext _context;

  public CategoryService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  public List<CategoryResponseDto> GetCategories()
  {
    return _context.Category.AsNoTracking().ProjectToType<CategoryResponseDto>().ToList();
  }
}
