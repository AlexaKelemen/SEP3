using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "User",
                newName: "BillingAddress");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Card",
                newName: "LName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Card",
                newName: "FName");

            migrationBuilder.AlterColumn<string>(
                name: "Cvc",
                table: "Card",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                columns: new[] { "Description", "ImageURL", "Name", "Price" },
                values: new object[] { "Tired of painful soles? Try this now!", "Images/Shoes/shoes1.png", "Comfy shoes", 10f });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Colour", "Description", "ImageURL", "Name", "Price", "Quantity", "Size" },
                values: new object[,]
                {
                    { 2, "Red", "Perfect fit for a runner", "Images/Shoes/shoes2.png", "Running shoes", 5f, 100, "Small" },
                    { 3, "Yellow", " Comfortable, long and flowy!", "Images/Clothing/clothing1.jpg", "Summer dress", 15f, 100, "Large" },
                    { 4, "Grey", "Classic white lace up sneakers with a minimalist design", "Images/Shoes/shoes4.png", "White Sneakers", 10f, 100, "Small" },
                    { 5, "Red", "Beautiful blend from white to black", "Images/Shoes/shoes5.png", "White and black ankle sneakers", 20f, 100, "Small" },
                    { 6, "Brown", "Perfect for driving people away from your house", "Images/accessories/Accessory21.png", "Amazing footmat", 30f, 100, "Small" },
                    { 7, "Black", "Stylish glasses with black, round frames", "Images/accessories/Accessory7.png", "Eyeglasses", 10f, 100, "Small" },
                    { 8, "Brown", "Brown hand bag with reinforced handles", "Images/accessories/Accessory11.png", "Small Hand bag", 27f, 100, "Small" },
                    { 9, "White", "Perfect gift to give to lovers of ducks!", "Images/accessories/Accessory14.png", "Funny ducks", 7f, 100, "Small" },
                    { 10, "Black & White", "Good, durable quality", "Images/accessories/Accessory19.png", "Funny clothespin", 5f, 100, "Small" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "BillingAddress",
                table: "User",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "LName",
                table: "Card",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FName",
                table: "Card",
                newName: "FirstName");

            migrationBuilder.AlterColumn<int>(
                name: "Cvc",
                table: "Card",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                columns: new[] { "Description", "ImageURL", "Name", "Price" },
                values: new object[] { "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Shoes/shoes1.png", "Glossier - Beauty Kit", 100f });
        }
    }
}
