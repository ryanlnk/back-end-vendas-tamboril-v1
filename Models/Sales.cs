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

  public Payment Payment { get; set; }
  public int PaymentId { get; set; }

  public BankAccount AccountBank { get; set; }
  public int AccountBankId { get; set; }

  public List<SalesHasProduct> SalesHasProducts { get; set; }
}
