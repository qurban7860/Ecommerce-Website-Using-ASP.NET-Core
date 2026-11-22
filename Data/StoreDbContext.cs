using EcommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Data;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    public static async Task SeedAsync(StoreDbContext db)
    {
        if (await db.Products.AnyAsync()) return;
        db.Products.AddRange(
            new Product { Name = "Wireless Headphones", Description = "Comfortable over-ear headphones with clear sound.", Price = 79.99m, Category = "Electronics", Stock = 15, ImageUrl = "https://placehold.co/600x400?text=Headphones" },
            new Product { Name = "Smart Watch", Description = "A simple everyday smartwatch with activity tracking.", Price = 119.00m, Category = "Electronics", Stock = 12, ImageUrl = "https://placehold.co/600x400?text=Smart+Watch" },
            new Product { Name = "Travel Backpack", Description = "Durable backpack for work, study, and travel.", Price = 49.50m, Category = "Accessories", Stock = 20, ImageUrl = "https://placehold.co/600x400?text=Backpack" },
            new Product { Name = "Desk Lamp", Description = "Minimal LED desk lamp for your workspace.", Price = 29.99m, Category = "Home", Stock = 18, ImageUrl = "https://placehold.co/600x400?text=Desk+Lamp" }
        );
        await db.SaveChangesAsync();
    }
}
