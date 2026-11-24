using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class SecurityDbContext(DbContextOptions<SecurityDbContext> options) : IdentityDbContext<eCommerce.Mvc.UI.Data.ApplicationUser>(options)
{
}
