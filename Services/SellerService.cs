using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Seller;
using VendasTamboril.Models;

namespace VendasTamboril.Services;

public class SellerService
{
  private readonly TamborilContext _context;

  public SellerService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  //Retornando todos os vendedores do banco de dados
  public List<SellerResponseDto> GetSellers()
  {
    return _context.Sellers.AsNoTracking().ProjectToType<SellerResponseDto>().ToList();
  }

  //Retornando somente um vendedor pelo ID
  public SellerResponseDto GetSeller(int id)
  {
    var seller = _context.Sellers.AsNoTracking().SingleOrDefault(c => c.Id == id);

    if (seller is null)
      return null;

    var sellerResponse = seller.Adapt<SellerResponseDto>();

    return sellerResponse;
  }

  //Adicionando um novo vendedor no banco de dados
  public SellerResponseDto PostSeller(SellerCreateUpdateDto sellerDto)
  {
    var seller = sellerDto.Adapt<Seller>();

    var dateNow = DateTime.Now;
    seller.CreationDate = dateNow;
    seller.UpdateDate = dateNow;

    _context.Sellers.Add(seller);
    _context.SaveChanges();

    var sellerResponse = seller.Adapt<SellerResponseDto>();

    return sellerResponse;
  }

  //Editando um vendedor já cadastrado no banco de dados
  public SellerResponseDto PutSeller(int id, SellerCreateUpdateDto sellerDto)
  {
    var seller = _context.Sellers.SingleOrDefault(c => c.Id == id);

    if (seller is null)
      return null;

    sellerDto.Adapt(seller);

    seller.UpdateDate = DateTime.Now;

    _context.SaveChanges();

    var sellerResponse = seller.Adapt<SellerResponseDto>();

    return sellerResponse;
  }

  //Deletando um vendedor
  public void DeleteSeller(int id)
  {
    var seller = _context.Sellers.SingleOrDefault(c => c.Id == id);

    if (seller is null)
      throw new Exception("Seller not found");

    _context.Remove(seller);
    _context.SaveChanges();
  }
}
