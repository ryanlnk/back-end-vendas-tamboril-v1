using Microsoft.EntityFrameworkCore;
using VendasTamboril.Models;

namespace VendasTamboril.Data;

public class TamborilContext : DbContext
{
  public TamborilContext(DbContextOptions<TamborilContext> options) : base(options) { }
  public DbSet<Customer> Customer { get; set; }
  public DbSet<Seller> Seller { get; set; }
  public DbSet<Payment> Payment { get; set; }

}