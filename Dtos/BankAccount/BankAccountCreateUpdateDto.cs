using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Dtos.BankAccount;

public class BankAccountCreateUpdateDto
{
  [Required]
  [StringLength(45, MinimumLength = 3)]
  public string Name { get; set; }
}
