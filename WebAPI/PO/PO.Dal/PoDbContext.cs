using Microsoft.EntityFrameworkCore;
using PO.Models;

namespace PO.Dal;

public class PoDbContext : DbContext
{
    public PoDbContext()
    {

    }
    public PoDbContext(DbContextOptions<PoDbContext> options) : base(options)
    {

    }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=WebApiPONov26Db;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}
