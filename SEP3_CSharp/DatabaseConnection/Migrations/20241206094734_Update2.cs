using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3,
                columns: new[] { "Colour", "ImageURL" },
                values: new object[] { "Green", "Images/Clothes/clothing1.jpg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Colour", "Description", "ImageURL", "Name", "Price", "Quantity", "Size" },
                values: new object[,]
                {
                    { 11, "Brown", "Durable but easily removed glue", "Images/accessories/Accessory17.png", "Funny sticker", 5f, 100, "Small" },
                    { 12, "Black & Brown", "Beautiful leather wallet", "Images/accessories/Accessory10.png", "Small, feminine wallet", 15f, 100, "Small" },
                    { 13, "Green", "Comfortable cotton. One out of 10 girls recommend", "Images/Clothes/clothing2.jpg", "Bright green dress", 25f, 100, "Small" },
                    { 14, "Black", "Very comfortable and stretchy material", "Images/Clothes/clothing3.jpg", "Beautiful black dinner dress", 35f, 100, "Small" },
                    { 15, "Black", "Sleek black boots with low heels and a zipper", "Images/shoes/shoes16.png", "Black ankle boots", 12f, 100, "Small" },
                    { 16, "Black", "Durable, stretchy bracelet", "Images/accessories/Accessory6.png", "Black bracelet", 5f, 100, "Small" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3,
                columns: new[] { "Colour", "ImageURL" },
                values: new object[] { "Yellow", "Images/Clothing/clothing1.jpg" });
        }
    }
}
