using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class killll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Colour", "Description", "ImageURL", "Name", "Price", "Quantity", "Size" },
                values: new object[] { 23, "White", "Make an impression, shine in your light", "Images/Clothes/clothing8.jpg", "Shine bright dress", 350f, 100, "Small" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 23);
        }
    }
}
