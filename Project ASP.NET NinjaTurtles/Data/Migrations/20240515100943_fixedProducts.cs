using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_ASP.NET_NinjaTurtles.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductsProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductsProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerBirthDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FKProductId",
                table: "Orders",
                column: "FKProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_FKProductId",
                table: "Orders",
                column: "FKProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_FKProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FKProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerBirthDate",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Customers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsProductId",
                table: "Orders",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductsProductId",
                table: "Orders",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
