using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Different kinds of clothing", "Clothing" },
                    { 2, "Different kinds of Shoes", "Shoes" },
                    { 3, "Different kinds of accessories", "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Colour", "Description", "ImageURL", "Name", "Price", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, "Blue", "Tired of painful soles? Try this now!", "Images/Shoes/shoes1.png", "Comfy shoes", 210f, 100, "Small" },
                    { 2, "Red", "Perfect fit for a runner", "Images/Shoes/shoes2.png", "Running shoes", 700f, 100, "Small" },
                    { 3, "Green", "Comfortable, long and flowy!", "Images/Clothes/clothing1.jpg", "Summer dress", 540f, 100, "Large" },
                    { 4, "Grey", "Classic white lace-up sneakers with a minimalist design", "Images/Shoes/shoes4.png", "White Sneakers", 1200f, 100, "Small" },
                    { 5, "Red", "Beautiful blend from white to black", "Images/Shoes/shoes5.png", "White and black ankle sneakers", 780f, 100, "Small" },
                    { 6, "Brown", "Perfect for driving people away from your house", "Images/accessories/Accessory21.png", "Amazing footmat", 280f, 100, "Small" },
                    { 7, "Black", "Stylish glasses with black, round frames", "Images/accessories/Accessory7.png", "Eyeglasses", 1003f, 100, "Small" },
                    { 8, "Brown", "Brown hand bag with reinforced handles", "Images/accessories/Accessory11.png", "Small Hand bag", 98f, 100, "Small" },
                    { 9, "White", "Perfect gift to give to lovers of ducks!", "Images/accessories/Accessory14.png", "Funny ducks", 65f, 100, "Small" },
                    { 10, "Black & White", "Good, durable quality", "Images/accessories/Accessory19.png", "Funny clothespin", 60f, 100, "Small" },
                    { 11, "Brown", "Durable but easily removed glue", "Images/accessories/Accessory17.png", "Funny sticker", 40f, 100, "Small" },
                    { 12, "Black & Brown", "Beautiful leather wallet", "Images/accessories/Accessory10.png", "Small, feminine wallet", 730f, 100, "Small" },
                    { 13, "Green", "Comfortable cotton. One out of 10 girls recommend", "Images/Clothes/clothing2.jpg", "Bright green dress", 350f, 100, "Small" },
                    { 14, "Black", "Very comfortable and stretchy material", "Images/Clothes/clothing3.jpg", "Beautiful black dinner dress", 1500f, 100, "Small" },
                    { 15, "Black", "Sleek black boots with low heels and a zipper", "Images/shoes/shoes16.png", "Black ankle boots", 2200f, 100, "Small" },
                    { 16, "Black", "Durable, stretchy bracelet", "Images/accessories/Accessory6.png", "Black bracelet", 250f, 100, "Small" },
                    { 17, "White", "Make an impression, shine in your light", "Images/Clothes/clothing8.jpg", "Shine bright dress", 350f, 100, "Small" },
                    { 18, "White", "The manifestation of elegance", "Images/Clothes/clothing4.jpg", "The flow dress", 500f, 100, "Small" },
                    { 19, "Red", "Unleash your inner diva", "Images/Clothes/clothing5.jpg", "The dress", 700f, 100, "Small" },
                    { 20, "Burgundy", "Make the billion-dollar deal in this dress", "Images/Clothes/clothing6.jpg", "Ultimate slay", 450f, 100, "Small" },
                    { 21, "Red", "Be the light of the dinner party", "Images/Clothes/clothing7.jpg", "Dinner served", 625f, 100, "Small" }
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "CategoryId", "ItemId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 1, 21 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 15 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 16 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 21);
        }
    }
}
