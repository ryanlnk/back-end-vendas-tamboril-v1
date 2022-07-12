using Microsoft.EntityFrameworkCore;
using VendasTamboril.Models;

namespace VendasTamboril.Data;

public class TamborilContext : DbContext
{
  public TamborilContext(DbContextOptions<TamborilContext> options) : base(options) { }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Seller> Sellers { get; set; }
  public DbSet<Payment> Payments { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Sales> Sales { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<BankAccount> BankAccounts { get; set; }
  public DbSet<SalesHasProduct> SalesHasProducts { get; set; }
}