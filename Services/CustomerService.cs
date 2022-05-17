using Microsoft.AspNetCore.Mvc;
using VendasTamboril.Data;
using VendasTamboril.Models;

namespace VendasTamboril.Services;

public class CustomerService
{
  private readonly TamborilContext _context;

  public CustomerService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  public List<Customer> GetCustomer()
  {
    return _context.Customer.ToList();
  }
  public Customer PostCustomer(Customer customer)
  {
    _context.Customer.Add(customer);
    _context.SaveChanges();
    return customer;
  }
}
