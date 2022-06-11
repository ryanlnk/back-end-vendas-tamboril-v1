using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Customer;
using VendasTamboril.Models;

namespace VendasTamboril.Services;

public class CustomerService
{
  private readonly TamborilContext _context;

  public CustomerService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  // Retornando uma lista com todos os clientes
  public List<CustomerResponseDto> GetCustomers()
  {
    return _context.Customer.AsNoTracking().ProjectToType<CustomerResponseDto>().ToList();
  }

  // Retornando um único cliente
  public CustomerResponseDto GetCustomer(int id)
  {
    var customer = _context.Customer.AsNoTracking().SingleOrDefault(c => c.Id == id);

    if (customer is null)
      return null;

    var customerResponse = customer.Adapt<CustomerResponseDto>();

    return customerResponse;
  }

  // Salvando um cliente
  public CustomerResponseDto PostCustomer(CustomerCreateUpdateDto customerDto)
  {
    // Mapeando os dados que foram recebidos do Dto para o Model
    var customer = customerDto.Adapt<Customer>();

    _context.Customer.Add(customer);
    _context.SaveChanges();

    // Mapaando os dados do Model para o Dto de resposta
    var customerResponse = customer.Adapt<CustomerResponseDto>();

    return customerResponse;
  }

  // Atualizando um cliente
  public CustomerResponseDto PutCustomer(int id, CustomerCreateUpdateDto customerDto)
  {
    // Buscar os dados do curso que está sendo editado
    var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

    if (customer is null)
      return null;

    customerDto.Adapt(customer);
    _context.SaveChanges();

    var customerResponse = customer.Adapt<CustomerResponseDto>();

    return customerResponse;
  }

  // Deletando um cliente
  public void DeleteCustomer(int id)
  {
    var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

    if (customer is null)
      throw new Exception("Customer not found");

    _context.Remove(customer);
    _context.SaveChanges();
  }
}
