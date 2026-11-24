using eCommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Dal;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext()
    {

    }
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=BajajEcomDbNov26Db;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}
