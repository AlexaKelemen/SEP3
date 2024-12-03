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
                    { 8, "Abracadbra", "Kick your enemies asses with these awesome brand new shoes", "/Images/shoes/shoes8", 49m, 87 },
                    { 9, "Original", "Black and White shoes for you to go to school. And then to work. Everyday. For the rest of your life",  "/Images/shoes/shoes9", 90m, 87},
                    { 10, "Just shoes", "I know these look like tires but what do I know about today's fashion?",  "/Images/shoes/shoes10", 90m, 37},
                    { 11, "Black hole", "Let your feet breathe. They stink",  "/Images/shoes/shoes11", 90m, 77},
                    { 12, "Newspaper", "Way to cheat on your exam. Thank me later",  "/Images/shoes/shoes12", 78m, 55},
                    { 13, "White sandals", "They go well with your white nails",  "/Images/shoes/shoes13", 90m, 77},
                    { 14, "QM", "Cute, everyday shoes, for active people",  "/Images/shoes/shoes14", 88m, 37 },
                    { 15, "Nature", "Multicolor shoes. They increase your winning chance if being chased by a chicken",  "/Images/shoes/shoes15", 90m, 77},
                    { 16, "Black boots", "yes, black, funeral style, because your feet look dead",  "/Images/shoes/shoes13", 110m, 77},
                    { 17, "1 December", "Winter is here. Keep your feet warm please",  "/Images/shoes/shoes17", 59m, 70},
                    { 18, "Cat Woman", "Pajama style. Cute and fluffy",  "/Images/shoes/shoes18", 90m, 77},
                    { 19, "Classic", "Me, my daughter, my mother and all my sisters have been wearing these for 2 years and no complains. Trust me, you should buy them too",  "/Images/shoes/shoes19", 50m, 88},
                    { 20, "Snow White", "Comfy like walking on a cloud",  "/Images/shoes/shoes20", 76m, 27}
                    
                }
            );
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    AccessoriesId = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table => { table.PrimaryKey("PK_Accessories", x => x.AccessoriesId); }
            );
            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "AccessoriesId", "Name", "Description", "ImageURL", "Price", "Quantity", "Colour" },
                values: new object[,]
                {
                    {1, "The adult crisis pin", "Lets suffer together", "/Images/accessories/accessory1", 100m, 120, "white" },
                    {2, "Belt", "You're too skinny. Go eat a burger", "/Images/accessories/accessory2", 100m, 120, "black" },
                    {3, "Apple keychain", "Someone took a bite, sorry", "/Images/accessories/accessory3", 100m, 120, "silver" },
                    {4, "Bee hive phone case", "Pretty", "/Images/accessories/accessory4", 100m, 120, "white and blue" },
                    {5, "Cute bears keychain", "I know you are lonely but you dont have to hate the bears. Its not their fault", "/Images/accessories/accessory5", 29m, 78, "white and brown"},
                    {6, "bracelet", "weird looking thing",  "/Images/accessories/accessory6", 10m, 120, "black"},
                    {7, "glasses", "Im blind too",  "/Images/accessories/accessory7", 100m, 120, "black"},
                    {8, "watch", "You'll probably be late anyway but sure ",  "/Images/accessories/accessory8", 80m, 120, "cherry red"},
                    {9, "wallet", "Don't pretend you have money. You don't",  "/Images/accessories/accessory9", 100m, 10, "brown"},
                    {10, "wallet", "Don't worry. There's enough space for your 100kr", "/Images/accessories/accessory10", 100m, 20, "black and brown"},
                    {11, "purse", "Cute, very cute",  "/Images/accessories/accessory11", 100m, 120, "gray"},
                    {12, "scarf", "Because there's no one to keep you warm, buy a scarf",  "/Images/accessories/accessory12", 100m, 120, "autumn colours"},
                    {13, "serial killers ducks", "watch your back", "/Images/accessories/accessory13", 100m, 120, "yellow" },
                    {14, "ducks", "watch your bellongings", "/Images/accessories/accessory14", 100m, 120, "white" },
                    {15, "pew pew", "you're in trouble", "/Images/accessories/accessory15", 20m, 20, "yellow" },
                    {16, "duck vader", "ducks", "/Images/accessories/accessory16", 20m, 20, "white" },
                    {17, "trauma", "my life since 2005", "/Images/accessories/accessory17", 100m, 120, "yellow" },
                    {18, "student tears", "the struggle is real", "/Images/accessories/accessory18", 66m, 120, "blue" },
                    {19, "brainless", "use it pls", "/Images/accessories/accessory19", 87m, 120, "white and black" },
                    {20, "nerd pins", "for your bag", "/Images/accessories/accessory20", 100m, 20, "all the colours"},
                    {21, "doormat", "for your unwanted relatives", "/Images/accessories/accessory21", 100m, 120, "brown"},
                    {22, "pin", "for all the fragile little boys out there", "/Images/accessories/accessory22", 100m, 120, "pink" },
                    {23, "control pin", "everything is fiiiine", "Images/accessories/accessory23", 100m, 120, "pink"},
                    
                    
                    
                    
                }
            ); 
              migrationBuilder.InsertData(
                            table: "Clothing",
                            columns: new[] { "ClothesId", "Name", "Description", "ImageURL", "Price", "Quantity", "Colour" },
                            values: new object[,]
                            {
                                {1, "Beautiful cottagecore dress", "Lets have a nice friendly picnick together!", "/Images/Clothes/clothing1", 100m, 120, "green and white" },
                                {2, "Show-off shoulders dress", "You will slay in this dress", "/Images/Clothes/clothing2", 100m, 120, "green and white" },
                                {3, "Sleek black dress", "In this dress you will look like a young lady taking donations", "/Images/Clothes/clothing3", 38m, 19, "pink" },
                                
                              
                                
                                
                            }
                        ); 
        }

    }
    
}
