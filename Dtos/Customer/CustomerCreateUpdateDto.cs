using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Dtos.Customer;

public class CustomerCreateUpdateDto
{
  [Required]
  [StringLength(255, MinimumLength = 3)]
  public string Name { get; set; }

  [Required]
  [StringLength(20, MinimumLength = 11)]
  public string CPF { get; set; }

  [Required]
  [StringLength(20, MinimumLength = 8)]
  public string Contact { get; set; }
}
