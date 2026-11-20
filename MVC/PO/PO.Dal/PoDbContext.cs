using Microsoft.EntityFrameworkCore;
using PO.Entites;

namespace PO.Dal
{
    public class PoDbContext : DbContext
    {
        public PoDbContext()
        {
            
        }
        public PoDbContext(DbContextOptions<PoDbContext> options):base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EfCorePoDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }
    }
}
