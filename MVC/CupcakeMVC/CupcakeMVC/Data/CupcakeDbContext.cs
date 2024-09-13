using CupcakeMVC.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CupcakeMVC.Data;

// dotnet ef migrations add <name of migration>
// dotnet ef database update

public class CupcakeDbContext : IdentityDbContext<IdentityUser>
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cupcake>().ToTable("Cupcake");
        
        // SEEDING PREPARATION
        var hasher = new PasswordHasher<IdentityUser>();
        var defaultUser = new IdentityUser
        {
            Id = "default-id",
            UserName = "default@example.com",
            NormalizedUserName = "DEFAULT@EXAMPLE.COM",
            Email = "default@example.com",
            NormalizedEmail = "DEFAULT@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "DefaultPassword123!"), // Passwords should in general not be written like this. Recommended to use env or something similar.
            SecurityStamp = string.Empty
        };
        
        // SEEDING
        modelBuilder.Entity<IdentityUser>().HasData(defaultUser);
        
        // Sizes
        modelBuilder.Entity<Size>().HasData(new Size { SizeId = 1, Name = "Bite Size" });
        modelBuilder.Entity<Size>().HasData(new Size { SizeId = 2, Name = "Small" });
        modelBuilder.Entity<Size>().HasData(new Size { SizeId = 3, Name = "Medium" });
        modelBuilder.Entity<Size>().HasData(new Size { SizeId = 4, Name = "Large" });
        modelBuilder.Entity<Size>().HasData(new Size { SizeId = 5, Name = "Almost Cake Size" });
        
        // Categories
        modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, Name = "Regular" });
        modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, Name = "Vegan" });
        modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, Name = "GlutenFree" });
        
        // Cupcakes: cupcakes by https://www.ediblearrangements.com/blog/types-of-cupcakes/
        modelBuilder.Entity<Cupcake>().HasData(new Cupcake 
        { 
            CupcakeId = 1, 
            Name = "Strawberry Shortcake", 
            Description = "Stuffed with fresh strawberries and topped with fluffy whipped cream, these strawberry shortcake cupcakes are simply divine. Plus, the vanilla cupcake batter couldn’t be easier to whip up.", 
            SizeId = 3, 
            CategoryId = 1,
            OwnerId = defaultUser.Id
        });
        modelBuilder.Entity<Cupcake>().HasData(new Cupcake 
        { 
            CupcakeId = 2, 
            Name = "Lemon Cupcakes", 
            Description = "Filled with lemon curd and topped with lemon buttercream frosting, these cupcakes are sweet, tangy, and jam-packed with flavor. They taste like lemon drop candies in cupcake form.", 
            SizeId = 3, 
            CategoryId = 1,
            OwnerId = defaultUser.Id
        });
        modelBuilder.Entity<Cupcake>().HasData(new Cupcake 
        { 
            CupcakeId = 3, 
            Name = "Chocolate Cupcakes with Peanut Butter Frosting", 
            Description = "These cupcakes are the ultimate chocolate and peanut butter dessert. A dollop of peanut butter frosting tops moist chocolate cupcakes with chocolate drizzle and mini peanut butter cups.These cupcakes are the ultimate chocolate and peanut butter dessert. A dollop of peanut butter frosting tops moist chocolate cupcakes with chocolate drizzle and mini peanut butter cups.", 
            SizeId = 2, 
            CategoryId = 1,
            OwnerId = defaultUser.Id
        });
        modelBuilder.Entity<Cupcake>().HasData(new Cupcake 
        { 
            CupcakeId = 4, 
            Name = "Coconut Cupcakes", 
            Description = "Have a penchant for coconut? These cupcakes are made with a soft, fluffy vanilla cake topped with a coconut cream cheese buttercream frosting. Toasted coconut sprinkled on top makes the entire cupcake tastier.", 
            SizeId = 2, 
            CategoryId = 2,
            OwnerId = defaultUser.Id
        });
    }
    
    public CupcakeDbContext(DbContextOptions<CupcakeDbContext> options) : base(options)
    {
    }
    public DbSet<IdentityUser>? User { get; set; }
    public DbSet<Cupcake>? Cupcake { get; set; }
    public DbSet<Size>? Size { get; set; }
    public DbSet<Category>? Category { get; set; }
}