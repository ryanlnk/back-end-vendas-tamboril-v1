using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasTamboril.Models;

public class SalesHasProduct
{
  [Required]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "decimal(10,2)")]
  public decimal Price { get; set; }

  [Required]
  public decimal Quantity { get; set; }

  [Required]
  [Column(TypeName = "decimal(10,2)")]
  public decimal SubTotal { get; set; }
}
