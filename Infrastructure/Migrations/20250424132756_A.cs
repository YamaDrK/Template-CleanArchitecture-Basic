using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Drinks" },
                    { 3, "Snacks" },
                    { 4, "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreationDate", "DeletionDate", "Email", "IsDeleted", "ModificationDate", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2004, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin@Admin.com", false, null, "123", 2 },
                    { 2, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User1@User.com", false, null, "123", 1 },
                    { 3, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User2@User.com", false, null, "123", 1 },
                    { 4, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User3@User.com", false, null, "123", 1 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreationDate", "DeletionDate", "Description", "IsDeleted", "ModificationDate", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tender grilled chicken breast with herbs.", false, null, "Grilled Chicken", 8.99m },
                    { 2, 2, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Freshly squeezed orange juice.", false, null, "Orange Juice", 3.5m },
                    { 3, 3, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Crispy salted potato chips.", false, null, "Potato Chips", 1.75m },
                    { 4, 4, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rich and moist chocolate layer cake.", false, null, "Chocolate Cake", 4.25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
