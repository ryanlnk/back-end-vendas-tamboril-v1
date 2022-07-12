using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Product;
using VendasTamboril.Models;

namespace VendasTamboril.Services;

public class ProductService
{
  private readonly TamborilContext _context;

  public ProductService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  public List<ProductResponseDto> GetProducts()
  {
    return _context.Products.Include(product => product.Category).AsNoTracking().ProjectToType<ProductResponseDto>().ToList();
  }

  public ProductResponseDto GetProduct(int id)
  {
    var product = _context.Products.Include(product => product.Category).AsNoTracking().SingleOrDefault(p => p.Id == id);

    if (product is null)
      return null;

    var productResponse = product.Adapt<ProductResponseDto>();

    return productResponse;
  }

  public ProductResponseDto PostProduct(ProductCreateUpdateDto productDto)
  {
    var product = productDto.Adapt<Product>();

    _context.Products.Add(product);
    _context.SaveChanges();

    var savedProduct = _context.Products.Include(product => product.Category).SingleOrDefault(p => p.Id == product.Id);

    var productResponse = savedProduct.Adapt<ProductResponseDto>();

    return productResponse;
  }

  public ProductResponseDto PutProduct(int id, ProductCreateUpdateDto productDto)
  {
    var product = _context.Products.Include(product => product.Category).SingleOrDefault(p => p.Id == id);

    if (product is null)
      return null;

    productDto.Adapt(product);

    _context.SaveChanges();

    var productResponse = product.Adapt<ProductResponseDto>();

    return productResponse;
  }

  public void DeleteProduct(int id)
  {
    var product = _context.Products.SingleOrDefault(p => p.Id == id);

    if (product is null)
      throw new Exception("Product not found");

    _context.Remove(product);
    _context.SaveChanges();
  }
}
