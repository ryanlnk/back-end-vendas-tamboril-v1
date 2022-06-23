using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Models;

public class Sales
{
  [Required]
  public int Id { get; set; }

  [Required]
  public DateTime Date { get; set; }
}
