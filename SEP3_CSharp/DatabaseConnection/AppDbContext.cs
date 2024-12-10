﻿using Entities;
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
    //public DbSet<Cart> Carts => Set<Cart>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 1,
            Name = "Comfy shoes",
            Description = "Tired of painful soles? Try this now!",
            ImageURL = "Images/Shoes/shoes1.png",
            Price = 270,
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
            Price = 675,
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
            Price = 540,
            Quantity = 100,
            Colour = "Green",
            Size = "Large",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 4,
            Name = "White Sneakers",
            Description =
                "Classic white lace up sneakers with a minimalist design",
            ImageURL = "Images/Shoes/shoes4.png",
            Price = 1100,
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
            Price = 710,
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
            Price = 250,
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
            Price = 1000,
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
            Price = 800,
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
            Price = 75,
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
            Price = 55,
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
            Price = 50,
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
            Price = 530,
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
            Price = 250,
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
            Price = 2500,
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
            Price = 1200,
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
            Price = 150,
            Quantity = 100,
            Colour = "Black",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 17,
            Name = "The flow dress",
            Description = "The manifestation of elegance",
            ImageURL = "Images/Clothes/clothing4.jpg",
            Price = 500,
            Quantity = 100,
            Colour = "White",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 18,
            Name = "The dress",
            Description = "Unleash your inner diva",
            ImageURL = "Images/Clothes/clothing5.jpg",
            Price = 700,
            Quantity = 100,
            Colour = "Red",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 19,
            Name = "Ultimate slay",
            Description = "Make the billion dollar deal in this dress",
            ImageURL = "Images/Clothes/clothing6.jpg",
            Price = 450,
            Quantity = 100,
            Colour = "Burgundy",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 20,
            Name = "Dinner served",
            Description = "Be the light of the dinner party",
            ImageURL = "Images/Clothes/clothing7.jpg",
            Price = 625,
            Quantity = 100,
            Colour = "Red",
            Size = "Small",
        });
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 21,
            Name = "Shine bright dress",
            Description = "Make an impression,shine in your light",
            ImageURL = "Images/Clothes/clothing8.jpg",
            Price = 350,
            Quantity = 100,
            Colour = "White",
            Size = "Small",
        });


        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 2,
            ItemId = 1,
        });

        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 2,
            ItemId = 2,
        });

        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 3,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 2,
            ItemId = 4,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 2,
            ItemId = 5,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 6,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 7,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 8,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 9,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 10,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 11,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 12,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 13,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 14,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 2,
            ItemId = 15,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 3,
            ItemId = 16,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 17,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 18,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 19,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 20,
        });
        modelBuilder.Entity<ItemCategory>().ToTable("CategoryItem");
        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory()
        {
            CategoryId = 1,
            ItemId = 21,
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