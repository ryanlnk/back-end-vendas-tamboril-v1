using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Dtos.Payment;

public class PaymentCreateUpdateDto
{
  [Required]
  [StringLength(255, MinimumLength = 3)]
  public string Name { get; set; }
}
