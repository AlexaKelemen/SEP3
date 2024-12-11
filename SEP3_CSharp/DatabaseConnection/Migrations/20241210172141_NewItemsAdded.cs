using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class Please : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 27);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Colour", "Description", "ImageURL", "Name", "Price", "Quantity", "Size" },
                values: new object[,]
                {
                    { 17, "White", "Make an impression, shine in your light", "Images/Clothes/clothing8.jpg", "Shine bright dress", 350f, 100, "Small" },
                    { 18, "White", "The manifestation of elegance", "Images/Clothes/clothing4.jpg", "The flow dress", 500f, 100, "Small" },
                    { 19, "Red", "Unleash your inner diva", "Images/Clothes/clothing5.jpg", "The dress", 700f, 100, "Small" },
                    { 20, "Burgundy", "Make the billion-dollar deal in this dress", "Images/Clothes/clothing6.jpg", "Ultimate slay", 450f, 100, "Small" },
                    { 21, "Red", "Be the light of the dinner party", "Images/Clothes/clothing7.jpg", "Dinner served", 625f, 100, "Small" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Colour", "Description", "ImageURL", "Name", "Price", "Quantity", "Size" },
                values: new object[,]
                {
                    { 22, "White", "Make an impression, shine in your light", "Images/Clothes/clothing8.jpg", "Shine bright dress", 350f, 100, "Small" },
                    { 24, "White", "The manifestation of elegance", "Images/Clothes/clothing4.jpg", "The flow dress", 500f, 100, "Small" },
                    { 25, "Red", "Be the light of the dinner party", "Images/Clothes/clothing7.jpg", "Dinner served", 625f, 100, "Small" },
                    { 26, "Burgundy", "Make the billion-dollar deal in this dress", "Images/Clothes/clothing6.jpg", "Ultimate slay", 450f, 100, "Small" },
                    { 27, "Red", "Unleash your inner diva", "Images/Clothes/clothing5.jpg", "The dress", 700f, 100, "Small" }
                });
        }
    }
}
