using VendasTamboril.Dtos.Product;

namespace VendasTamboril.Dtos.SalesHasProduct;

public class SalesHasProductResponseDto
{
  public int Id { get; set; }

  public decimal Price { get; set; }

  public decimal Quantity { get; set; }

  public decimal SubTotal { get; set; }

  public string PaymentTerms { get; set; }

  public ProductResponseDto Product { get; set; }
}
