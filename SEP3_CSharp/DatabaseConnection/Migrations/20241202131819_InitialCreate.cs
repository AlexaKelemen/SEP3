﻿using Entities;
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
                    { 1,  "Comfy, thick base and lace, beige-coloured shoes", "/Images/shoes/shoes1", 30m, 70 },
                    { 2,  "Everyday, super comfortable shoes ", "/Images/shoes/shoes2", 30m, 78 },
                    { 3,  "Black shoes. Your feet will thank you ", "/Images/shoes/shoes3", 30m, 100 },
                    { 4,  "Black and white trainers with thick laces", "/Images/shoes/shoes4", 30m, 120 },
                    
                }
            );
        }

    }
    
}
