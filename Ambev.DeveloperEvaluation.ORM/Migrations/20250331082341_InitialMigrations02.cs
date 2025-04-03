using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInCart",
                table: "ProductsInCart");

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "ProductsInCart",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInCart",
                table: "ProductsInCart",
                columns: new[] { "CartId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Carts_CartId",
                table: "ProductsInCart",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Carts_CartId",
                table: "ProductsInCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInCart",
                table: "ProductsInCart");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ProductsInCart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInCart",
                table: "ProductsInCart",
                column: "Id");
        }
    }
}
