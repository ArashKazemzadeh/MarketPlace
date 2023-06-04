using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomertId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "11337733-16b4-4f16-924f-7fcbb481f671");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f2a69889-125c-46fd-b171-b78344ee8570");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5ce96e7c-0372-46fb-9d4b-2ec1523e6575");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomertId", "RegisterDate" },
                values: new object[] { 1, new DateTime(2023, 6, 4, 18, 1, 54, 411, DateTimeKind.Local).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CustomertId", "RegisterDate" },
                values: new object[] { 2, new DateTime(2023, 6, 4, 18, 1, 54, 411, DateTimeKind.Local).AddTicks(676) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CustomertId", "RegisterDate" },
                values: new object[] { 2, new DateTime(2023, 6, 4, 18, 1, 54, 411, DateTimeKind.Local).AddTicks(678) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomertId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f9558069-d498-447c-9ef2-1d3eb3e4fb82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f4dcd4b7-0c55-47c2-8ce9-71cc0bb25760");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f0db0a75-0a17-4fc3-902f-2fa538e0a5ac");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomertId", "RegisterDate" },
                values: new object[] { null, new DateTime(2023, 6, 4, 11, 56, 15, 177, DateTimeKind.Local).AddTicks(8226) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CustomertId", "RegisterDate" },
                values: new object[] { null, new DateTime(2023, 6, 4, 11, 56, 15, 177, DateTimeKind.Local).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CustomertId", "RegisterDate" },
                values: new object[] { null, new DateTime(2023, 6, 4, 11, 56, 15, 177, DateTimeKind.Local).AddTicks(8244) });
        }
    }
}
