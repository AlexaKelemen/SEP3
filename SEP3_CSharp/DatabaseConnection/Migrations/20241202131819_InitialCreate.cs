using Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConnection.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table => { table.PrimaryKey("PK_Items", x => x.ItemId); }
            );
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Name", "Description", "ImageURL", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Trainers", "Comfy, thick base and lace, beige-coloured shoes", "/Images/shoes/shoes1", 30m, 70 },
                    { 2, "Trainers", "Everyday, super comfortable shoes ", "/Images/shoes/shoes2", 30m, 78 },
                    { 3, "Trainers", "Black shoes. Your feet will thank you ", "/Images/shoes/shoes3", 30m, 100 },
                    { 4, "Trainers", "Black and white trainers with thick laces", "/Images/shoes/shoes4", 35m, 120 },
                    { 5, "Trainers", "Black and white running shoes. Healthy feet in pretty shoes", "/Images/shoes/shoes5", 30m, 120 },
                    { 6, "Trainers", "Black shoes. Perfect for making your friends jealous ", "/Images/shoes/shoes6", 90m, 102 },
                    { 7, "Cahhrrn",  "Let your friends know you are rich. Crazy rich.", "/Images/shoes/shoes7", 90m, 120 },
                    { 8, "Abracadbra", "Kick your enemies asses with these awesome brand new shoes", "/Images/shoes/shoes8", 90m, 87 },
                    { 9, "Original", "Black and White shoes for you to go to school. And then to work. Everyday. For the rest of your life",  "/Images/shoes/shoes9", 90m, 87},
                    { 10, "Just shoes", "I know these look like tires but what do I know about today's fashion?",  "/Images/shoes/shoes10", 90m, 87},
                    
                    
                    
                }
            );
        }

    }
    
}
