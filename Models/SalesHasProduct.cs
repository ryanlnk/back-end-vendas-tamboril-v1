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

  [Required]
  [Column(TypeName = "varchar(45)")]
  public string PaymentTerms { get; set; }

  public Sales Sales { get; set; }
  public int SalesId { get; set; }

  public Product Product { get; set; }
  public int ProductId { get; set; }
}
