using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasTamboril.Models;

public class Customer
{
  [Required]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "varchar(255)")]
  public string Name { get; set; }

  [Required]
  [Column(TypeName = "varchar(255)")]
  public string Email { get; set; }

  [Required]
  [Column(TypeName = "varchar(255)")]
  public string Contact { get; set; }

  [Required]
  public DateTime BirthDate { get; set; }

  public DateTime CreationDate { get; set; }

  public DateTime UpdateDate { get; set; }

  [Required]
  [Column(TypeName = "varchar(20)")]
  public string CPF { get; set; }

  public List<Sales> Sales { get; set; }
}
