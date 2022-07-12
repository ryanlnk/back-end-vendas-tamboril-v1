using VendasTamboril.Dtos.Category;

namespace VendasTamboril.Dtos.Product;

public class ProductResponseDto
{
  public int Id { get; set; }

  public string Name { get; set; }

  public decimal SalePrice { get; set; }

  public string Description { get; set; }

  public decimal Quantity { get; set; }

  public CategoryResponseDto Category { get; set; }
}
