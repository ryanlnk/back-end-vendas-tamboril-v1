using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Dtos.Product;

public class ProductCreateUpdateDto
{
  [Required]
  [StringLength(45, MinimumLength = 3)]
  public string Name { get; set; }

  [Required]
  public decimal SalePrice { get; set; }

  [StringLength(45, MinimumLength = 3)]
  public string Description { get; set; }

  [Required]
  public decimal Quantity { get; set; }

  [Required]
  public int CategoryId { get; set; }
}
