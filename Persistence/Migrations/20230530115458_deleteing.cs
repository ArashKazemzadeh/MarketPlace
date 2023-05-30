using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "ProductsCarts");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Medals");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Booths");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Admins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "ProductsCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Medals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Invoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Image",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Booths",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Bids",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Auctions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
