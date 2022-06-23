using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Category;
using VendasTamboril.Models;

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

  public CategoryResponseDto GetCategory(int id)
  {
    var category = _context.Category.AsNoTracking().SingleOrDefault(c => c.Id == id);

    if (category is null)
      return null;

    var categoryResponse = category.Adapt<CategoryResponseDto>();

    return categoryResponse;
  }

  public CategoryResponseDto PostCategory(CategoryCreateUpdateDto categoryDto)
  {
    var category = categoryDto.Adapt<Category>();

    var dateNow = DateTime.Now;
    category.CreationDate = dateNow;
    category.UpdateDate = dateNow;

    _context.Category.Add(category);
    _context.SaveChanges();

    var categoryResponse = category.Adapt<CategoryResponseDto>();

    return categoryResponse;
  }

  public CategoryResponseDto PutCategory(int id, CategoryCreateUpdateDto categoryDto)
  {
    var category = _context.Category.SingleOrDefault(c => c.Id == id);

    if (category is null)
      return null;

    categoryDto.Adapt(category);

    category.UpdateDate = DateTime.Now;
    _context.SaveChanges();

    var categoryResponse = category.Adapt<CategoryResponseDto>();

    return categoryResponse;
  }
}
