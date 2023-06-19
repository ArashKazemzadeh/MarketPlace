using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "ProductsCarts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2e6c9bc2-3157-49f9-8135-7fd95ffa9674");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3d79e041-1f2a-4946-872a-093046061085");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a2ceb26f-63ff-46a9-900f-2ab5c0b7fbd0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "0116249d-9993-4fe7-8ea5-3a6690e92cb8");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 19, 23, 11, 36, 830, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 19, 23, 11, 36, 830, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 19, 23, 11, 36, 830, DateTimeKind.Local).AddTicks(8619));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "ProductsCarts");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrices = table.Column<int>(type: "int", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Invoice__D796AAD5A0B9A395", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Invoice__Shoppin__4E88ABD4",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cf70c60e-3de7-4749-b6dd-d4862d409dc1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c01c1083-3a7f-464f-ad54-f1efa9a18a92");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "739362e9-efba-4e8b-becc-0d909a97c3c0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "74c2e1ce-687a-4b6f-8ad7-813bacdd9745");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 19, 13, 45, 37, 896, DateTimeKind.Local).AddTicks(2825));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 19, 13, 45, 37, 896, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 19, 13, 45, 37, 896, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CartID",
                table: "Invoice",
                column: "CartID");
        }
    }
}
