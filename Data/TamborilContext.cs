using Microsoft.EntityFrameworkCore;
using VendasTamboril.Models;

namespace VendasTamboril.Data;

public class TamborilContext : DbContext
{
  public TamborilContext(DbContextOptions<TamborilContext> options) : base(options) { }
  public DbSet<Customer> Customer { get; set; }

}