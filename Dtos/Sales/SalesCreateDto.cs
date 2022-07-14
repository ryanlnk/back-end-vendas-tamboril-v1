using System.ComponentModel.DataAnnotations;
using VendasTamboril.Dtos.SalesHasProduct;

namespace VendasTamboril.Dtos.Sales;

public class SalesCreateDto
{
  [Required]
  public int SellerId { get; set; }

  [Required]
  public int CustomerId { get; set; }

  [Required]
  public int PaymentId { get; set; }

  [Required]
  public int AccountBankId { get; set; }

  [Required]
  public List<SalesHasProductCreateDto> SalesHasProducts { get; set; }
}
