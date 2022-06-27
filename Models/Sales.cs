using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Models;

public class Sales
{
  [Required]
  public int Id { get; set; }

  [Required]
  public DateTime Date { get; set; }

  public Customer Customer { get; set; }
  public int CustomerId { get; set; }

  public Seller Seller { get; set; }
  public int SellerId { get; set; }

  public List<SalesHasProduct> SalesHasProducts { get; set; }
  public List<SalesHasPayment> SalesHasPayments { get; set; }
}
