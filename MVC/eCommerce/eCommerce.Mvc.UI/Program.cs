using eCommerce.Application;
using eCommerce.Dal;
using eCommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;
using eCommerce.Mvc.UI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("eCommConStr"));
});

builder.Services.AddDbContext<SecurityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("eCommConStr"));
});
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SecurityDbContext>();

builder.Services.AddInfrastructureRegistrations();
builder.Services.AddServiceRegistrations();

builder.Services.AddSession(sessionConfig =>
{
    sessionConfig.Cookie.HttpOnly = true;
    sessionConfig.Cookie.IsEssential = true;
    //sessionConfig.Cookie.Expiration = new TimeSpan(00, 10, 00);
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    ).WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();
#region Seed Security Data
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Customer" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
//Creating Users  - This block will get executed everytime the application starts/restarts. We are seeding the users
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string adminUser = "admin@ecommerce.com";
    string adminPassword = "Welcome@123";
    if (await userManager.FindByEmailAsync(adminUser) == null)
    {
        var user = new ApplicationUser() { UserName = adminUser, Email = adminUser };
        await userManager.CreateAsync(user, adminPassword);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}
#endregion
app.Run();
