using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionPercentage",
                table: "Product");

            migrationBuilder.AddColumn<double>(
                name: "CommissionPercentage",
                table: "Sellers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "ISAccepted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomertId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ISAccepted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HighestPrice",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SellerId",
                table: "Carts",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Sellers_SellerId",
                table: "Carts",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customer_CustomerId",
                table: "Comments",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Sellers_SellerId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customer_CustomerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Carts_SellerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CommissionPercentage",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "ISAccepted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CustomertId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ISAccepted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "HighestPrice",
                table: "Auctions");

            migrationBuilder.AddColumn<double>(
                name: "CommissionPercentage",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
