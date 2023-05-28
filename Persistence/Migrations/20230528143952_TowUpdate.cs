using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TowUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medal_Seller",
                table: "Medals");

            migrationBuilder.DropColumn(
                name: "ISAccepted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medals");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "InAuction",
                table: "Product",
                newName: "IsAuction");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Medals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Medals_Sellers_SellerId",
                table: "Medals",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medals_Sellers_SellerId",
                table: "Medals");

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IsAuction",
                table: "Product",
                newName: "InAuction");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Product",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "ISAccepted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Medals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsAccepted",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medal_Seller",
                table: "Medals",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }
    }
}
