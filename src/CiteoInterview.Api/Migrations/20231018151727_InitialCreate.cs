using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CiteoInterview.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreationDate", "Email", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(590), "pierre@citeo.com", null },
                    { 2, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(650), "paul@citeo.com", null },
                    { 3, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(650), "jaque@citeo.com", null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreationDate", "Name", "Price", "Stock", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(420), "IMac", 2500, 10, null },
                    { 2, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(460), "Iphone", 800, 150, null },
                    { 3, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(460), "Ipad", 500, 88, null },
                    { 4, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(460), "Casque Bose", 400, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreationDate", "CustomerId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(670), 1, null },
                    { 2, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(670), 2, null },
                    { 3, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(670), 3, null }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "CreationDate", "OrderId", "ProductId", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(680), 1, 1, 10, null },
                    { 2, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(690), 2, 2, 1, null },
                    { 3, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(690), 2, 3, 1, null },
                    { 4, new DateTime(2023, 10, 18, 17, 17, 27, 642, DateTimeKind.Local).AddTicks(690), 3, 4, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
