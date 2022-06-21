namespace VendasTamboril.Dtos.Customer;

public class CustomerResponseDto
{
  public int Id { get; set; }

  public string Name { get; set; }

  public string Email { get; set; }

  public string Contact { get; set; }

  public DateTime BirthDate { get; set; }

  public DateTime UpdateDate { get; set; }

  public string CPF { get; set; }
}
