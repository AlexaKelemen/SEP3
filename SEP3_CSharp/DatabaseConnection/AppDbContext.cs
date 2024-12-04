using Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;


namespace DatabaseConnection;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 1,
            Name = "Glossier - Beauty Kit",
            Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
            ImageURL = "/Images/Shoes/shoes1.png",
            Price = 100,
            Quantity = 100,
            Colour = "Blue",
            Size = "Small",
        });
    }
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<DeliveryOption> DeliveryOptions => Set<DeliveryOption>();
}
