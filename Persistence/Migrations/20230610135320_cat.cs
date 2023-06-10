using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "68dda470-6876-42fa-8232-1ecfb337b61c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "72456a32-6ebf-4d90-9750-2a48b8d4328d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "092f7016-bd21-410a-9780-814813e28033");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "9b53c62b-d2a4-4678-badf-235f534704f3");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "InsertTime", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "لپ تاپ جدید و بسیار کارآمد", null, "تکنولوژی", null, null },
                    { 2, "لپ تاپ جدید و بسیار کارآمد", null, "تکنولوژی", null, null },
                    { 3, "لپ تاپ جدید و بسیار کارآمد", null, "تکنولوژی", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 10, 17, 23, 20, 438, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 10, 17, 23, 20, 438, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 10, 17, 23, 20, 438, DateTimeKind.Local).AddTicks(7664));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ff35bb1c-d571-4e05-96c4-57757d9eaf29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5913644e-8cbb-4dde-adfa-9c8d1a02e719");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "94e81b41-73f4-4145-b169-902331f45ed6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "e49a95f8-9bdb-42a0-a832-d4a33ffdee28");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 10, 13, 37, 17, 587, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 10, 13, 37, 17, 587, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 10, 13, 37, 17, 587, DateTimeKind.Local).AddTicks(1843));
        }
    }
}
