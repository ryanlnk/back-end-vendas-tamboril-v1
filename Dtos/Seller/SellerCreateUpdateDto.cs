using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Dtos.Seller;

public class SellerCreateUpdateDto
{
  [Required]
  [StringLength(255, MinimumLength = 3)]
  public string Name { get; set; }
}
