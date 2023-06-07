using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                value: "5139d7db-2589-4d85-8666-eaefdd258586");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f8f879a2-d8ff-4c02-b0da-dfb583bc456a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "3fd2c949-fda9-4329-bb17-6681f59248bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "aa7e349a-2c1d-49f0-b88d-138b83ca253e");

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "شماره یک مواد غذایی");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 7, 15, 28, 0, 173, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 7, 15, 28, 0, 173, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 7, 15, 28, 0, 173, DateTimeKind.Local).AddTicks(3660));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "001a3192-5cf6-4b9f-a2af-69832712ce43");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "dc546735-1191-446b-9f85-d7929a62916a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "36eaa506-1ef4-418d-895c-27f3bc156647");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "d5981945-95e7-44e2-863e-bef6751726f2");

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "غذایی");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 7, 14, 48, 16, 994, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 7, 14, 48, 16, 994, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 7, 14, 48, 16, 994, DateTimeKind.Local).AddTicks(2633));
        }
    }
}
