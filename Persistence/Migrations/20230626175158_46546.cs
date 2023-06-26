using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _46546 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Customer_AuctionId",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Bids",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "88da7713-3870-43ee-8fca-600eb61580d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1687d0fe-d026-438b-b4ab-c6bf1cd17033");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "24b5d1ee-0720-41f6-996c-ce341aaba102");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b5972437-a355-4ea2-81c4-1fca320a6ebb");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 26, 21, 21, 57, 870, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 26, 21, 21, 57, 870, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 26, 21, 21, 57, 870, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.CreateIndex(
                name: "IX_Bids_CustomerId",
                table: "Bids",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Customer_CustomerId",
                table: "Bids",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Customer_CustomerId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_CustomerId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bids");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "29cbc23e-ce51-477f-a3fa-cedadfff67cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "21186276-e815-441f-b2ed-e7d330744924");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8c8961cc-4287-4111-b183-03585136165a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "ff91f37f-5a1e-449f-8ec1-a1c9e2160f35");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 26, 17, 38, 33, 17, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 26, 17, 38, 33, 17, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 26, 17, 38, 33, 17, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Customer_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
