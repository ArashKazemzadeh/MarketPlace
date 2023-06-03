using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5e2be3fa-0b1c-4266-97a5-51150751306a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "66bf9df3-bac0-4047-b5c7-2488748eae11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0f0b70c3-03e6-478b-8ef8-b9e13768d892");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CustomerId", "CustomertId", "Description", "InsertTime", "IsConfirm", "ProductId", "RegisterDate", "RemoveTime", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, "این محصول عالی است.", null, true, 1, new DateTime(2023, 6, 3, 21, 10, 37, 636, DateTimeKind.Local).AddTicks(2531), null, "عالی", null },
                    { 2, null, null, "این محصول بد است.", null, false, 1, new DateTime(2023, 6, 3, 21, 10, 37, 636, DateTimeKind.Local).AddTicks(2553), null, "بد", null },
                    { 20, null, null, "این محصول خوب است.", null, true, 2, new DateTime(2023, 6, 3, 21, 10, 37, 636, DateTimeKind.Local).AddTicks(2555), null, "خوب", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a2c3353e-a7c5-4858-bd42-c38d6eda0b91");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "da6c3d64-c1f4-4772-b8aa-430e2206ad6c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "cf98734d-7e63-453a-a1bf-36f4728477d9");
        }
    }
}
