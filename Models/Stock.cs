using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasTamboril.Models;

public class Stock
{
  [Required]
  public int Id { get; set; }

  [Required]
  public DateTime Date { get; set; }

  [Required]
  public decimal Quantity { get; set; }

  [Required]
  [Column(TypeName = "decimal(10,2)")]
  public decimal BuyPrice { get; set; }

  public Product Product { get; set; }
  public int ProductId { get; set; }
}
