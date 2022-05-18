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

  public List<Customer> GetCustomers()
  {
    return _context.Customer.ToList();
  }

  public Customer GetCustomer(int id)
  {
    var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

    if (customer is null)
      return null;

    return customer;
  }

  public Customer PostCustomer(Customer customer)
  {
    _context.Customer.Add(customer);
    _context.SaveChanges();
    return customer;
  }

  public Customer PutCustomer(int id, Customer c)
  {
    Customer customer = _context.Customer.SingleOrDefault(c => c.Id == id);

    if (customer is null)
      return null;

    customer.Name = c.Name;
    customer.Email = c.Email;
    customer.Contact = c.Contact;
    customer.BirthDate = c.BirthDate;
    customer.CPF = c.CPF;

    _context.SaveChanges();

    return customer;
  }

  public void DeleteCustomer(int id)
  {
    var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

    if (customer is null)
      throw new Exception("Customer not found");

    _context.Remove(customer);
    _context.SaveChanges();
  }
}
