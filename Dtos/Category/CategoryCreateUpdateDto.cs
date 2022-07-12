using System.ComponentModel.DataAnnotations;

namespace VendasTamboril.Dtos.Category;

public class CategoryCreateUpdateDto
{
  [Required]
  [StringLength(255, MinimumLength = 3)]
  public string Name { get; set; }
}
