namespace VendasTamboril.Dtos.Customer;

public class CustomerCreateUpdateDto
{
  public string Name { get; set; }

  public string Email { get; set; }

  public string Contact { get; set; }

  public DateTime BirthDate { get; set; }

  public string CPF { get; set; }
}
