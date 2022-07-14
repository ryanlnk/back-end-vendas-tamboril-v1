using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Dtos.SalesHasProduct;

public class SalesHasProductCreateDto
{
  [Required]
  public int ProductId { get; set; }

  [Required]
  public decimal Price { get; set; }

  [Required]
  public decimal Quantity { get; set; }

  [Required]
  public string PaymentTerms { get; set; }
}
