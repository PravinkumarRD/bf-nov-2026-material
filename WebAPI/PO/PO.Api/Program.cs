using Microsoft.EntityFrameworkCore;
using PO.Application;
using PO.Dal;
using PO.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConStr"));
});
builder.Services.AddInfrastructureRegistrations();
builder.Services.AddServiceRegistrations();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
