using CupcakeMVC.Data;
using CupcakeMVC.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CupcakeContextConnection") ?? throw new InvalidOperationException("Connection string 'CupcakeDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICupcakeRepository, CupcakeRepository>();
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

// DB Services
builder.Services.AddDbContext<CupcakeDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cupcake}/{action=Index}/{id?}");

app.Run();