using Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;


namespace DatabaseConnection;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<DeliveryOption> DeliveryOptions => Set<DeliveryOption>();
    public DbSet<Cart> Carts => Set<Cart>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 1,
            Name = "Comfy shoes",
            Description = "Tired of painful soles? Try this now!",
            ImageURL = "Images/Shoes/shoes1.png",
            Price = 10,
            Quantity = 100,
            Colour = "Blue",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 2,
            Name = "Running shoes",
            Description = "Perfect fit for a runner",
            ImageURL = "Images/Shoes/shoes2.png",
            Price = 5,
            Quantity = 100,
            Colour = "Red",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 3,
            Name = "Summer dress",
            Description = " Comfortable, long and flowy!",
            ImageURL = "Images/Clothes/clothing1.jpg",
            Price = 15,
            Quantity = 100,
            Colour = "Green",
            Size = "Large",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 4,
            Name = "White Sneakers",
            Description = "Classic white lace up sneakers with a minimalist design",
            ImageURL = "Images/Shoes/shoes4.png",
            Price = 10,
            Quantity = 100,
            Colour = "Grey",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 5,
            Name = "White and black ankle sneakers",
            Description = "Beautiful blend from white to black",
            ImageURL = "Images/Shoes/shoes5.png",
            Price = 20,
            Quantity = 100,
            Colour = "Red",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 6,
            Name = "Amazing footmat",
            Description = "Perfect for driving people away from your house",
            ImageURL = "Images/accessories/Accessory21.png",
            Price = 30,
            Quantity = 100,
            Colour = "Brown",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 7,
            Name = "Eyeglasses",
            Description = "Stylish glasses with black, round frames",
            ImageURL = "Images/accessories/Accessory7.png",
            Price = 10,
            Quantity = 100,
            Colour = "Black",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 8,
            Name = "Small Hand bag",
            Description = "Brown hand bag with reinforced handles",
            ImageURL = "Images/accessories/Accessory11.png",
            Price = 27,
            Quantity = 100,
            Colour = "Brown",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 9,
            Name = "Funny ducks",
            Description = "Perfect gift to give to lovers of ducks!",
            ImageURL = "Images/accessories/Accessory14.png",
            Price = 7,
            Quantity = 100,
            Colour = "White",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 10,
            Name = "Funny clothespin",
            Description = "Good, durable quality",
            ImageURL = "Images/accessories/Accessory19.png",
            Price = 5,
            Quantity = 100,
            Colour = "Black & White",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 11,
            Name = "Funny sticker",
            Description = "Durable but easily removed glue",
            ImageURL = "Images/accessories/Accessory17.png",
            Price = 5,
            Quantity = 100,
            Colour = "Brown",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 12,
            Name = "Small, feminine wallet",
            Description = "Beautiful leather wallet",
            ImageURL = "Images/accessories/Accessory10.png",
            Price = 15,
            Quantity = 100,
            Colour = "Black & Brown",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 13,
            Name = "Bright green dress",
            Description = "Comfortable cotton. One out of 10 girls recommend",
            ImageURL = "Images/Clothes/clothing2.jpg",
            Price = 25,
            Quantity = 100,
            Colour = "Green",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 14,
            Name = "Beautiful black dinner dress",
            Description = "Very comfortable and stretchy material",
            ImageURL = "Images/Clothes/clothing3.jpg",
            Price = 35,
            Quantity = 100,
            Colour = "Black",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 15,
            Name = "Black ankle boots",
            Description = "Sleek black boots with low heels and a zipper",
            ImageURL = "Images/shoes/shoes16.png",
            Price = 12,
            Quantity = 100,
            Colour = "Black",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 16,
            Name = "Black bracelet",
            Description = "Durable, stretchy bracelet",
            ImageURL = "Images/accessories/Accessory6.png",
            Price = 5,
            Quantity = 100,
            Colour = "Black",
            Size = "Small",
        });
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Category>().HasData(new Category
        {
           CategoryId = 1,
           CategoryName = "Clothing",
           CategoryDescription = "Different kinds of clothing"
        });
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 2,
            CategoryName = "Shoes",
            CategoryDescription = "Different kinds of Shoes"
        });
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 3,
            CategoryName = "Accessories",
            CategoryDescription = "Different kinds of accessories"
        });
    }
    
}
