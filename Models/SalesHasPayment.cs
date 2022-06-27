using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasTamboril.Models;

public class SalesHasPayment
{
  [Required]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "decimal(10,2)")]
  public decimal Value { get; set; }

  [Required]
  [Column(TypeName = "varchar(10)")]
  public string Status { get; set; }

  [Required]
  public DateTime Date { get; set; }

  public Payment Payment { get; set; }
  public int PaymentId { get; set; }

  public Sales Sales { get; set; }
  public int SalesId { get; set; }
}
