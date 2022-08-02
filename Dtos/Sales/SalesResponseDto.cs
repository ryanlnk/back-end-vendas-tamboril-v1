using VendasTamboril.Dtos.BankAccount;
using VendasTamboril.Dtos.Customer;
using VendasTamboril.Dtos.Payment;
using VendasTamboril.Dtos.SalesHasProduct;
using VendasTamboril.Dtos.Seller;

namespace VendasTamboril.Dtos.Sales;

public class SalesResponseDto
{
  public int Id { get; set; }

  public DateTime Date { get; set; }

  public decimal SubTotal { get; set; }

  public CustomerResponseDto Customer { get; set; }

  public SellerResponseDto Seller { get; set; }

  public PaymentResponseDto Payment { get; set; }

  public BankAccountResponseDto AccountBank { get; set; }

  public List<SalesHasProductResponseDto> SalesHasProducts { get; set; }
}
