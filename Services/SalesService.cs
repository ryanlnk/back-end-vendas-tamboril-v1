using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Sales;
using VendasTamboril.Models;

namespace VendasTamboril.Services;

public class SalesService
{
  private readonly TamborilContext _context;

  public SalesService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  public List<SalesResponseDto> GetSales()
  {
    return _context.Sales
    .AsNoTracking()
    .ProjectToType<SalesResponseDto>().ToList();
  }

  public SalesResponseDto GetSale(int id)
  {
    var sale = _context.Sales.AsNoTracking()
    .Include(sale => sale.Seller)
    .Include(sale => sale.Customer)
    .Include(sale => sale.Payment)
    .Include(sale => sale.AccountBank)
    .Include(sale => sale.SalesHasProducts)
    .ThenInclude(salesHasProduct => salesHasProduct.Product)
    .SingleOrDefault(s => s.Id == id);

    if (sale is null)
      return null;

    var saleResponse = sale.Adapt<SalesResponseDto>();

    return saleResponse;
  }

  public SalesResponseDto PostSale(SalesCreateDto saleDto)
  {
    var sale = saleDto.Adapt<Sales>();

    sale.Date = DateTime.Now;

    _context.Sales.Add(sale);
    _context.SaveChanges();

    var saleResponse = sale.Adapt<SalesResponseDto>();

    return saleResponse;
  }

  public void DeleteSale(int id)
  {
    var sale = _context.Sales.SingleOrDefault(s => s.Id == id);

    if (sale is null)
      throw new Exception("Sale not found");

    _context.Remove(sale);
    _context.SaveChanges();
  }
}
