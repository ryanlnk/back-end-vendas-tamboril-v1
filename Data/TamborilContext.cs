using Microsoft.EntityFrameworkCore;
using VendasTamboril.Models;

namespace VendasTamboril.Data;

public class TamborilContext : DbContext
{
  public TamborilContext(DbContextOptions<TamborilContext> options) : base(options) { }
  public DbSet<Customer> Customer { get; set; }
  public DbSet<Seller> Seller { get; set; }
  public DbSet<Payment> Payment { get; set; }
  public DbSet<Category> Category { get; set; }
  public DbSet<Sales> Sales { get; set; }
  public DbSet<Product> Product { get; set; }
  public DbSet<AccountBank> AccountBank { get; set; }
  public DbSet<SalesHasProduct> SalesHasProduct { get; set; }
}