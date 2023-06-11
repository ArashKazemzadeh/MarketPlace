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
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber" },
                values: new object[] { "6845875c-235f-4b1a-aa4a-645e7e0d7f12", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "FullName", "UserName" },
                values: new object[] { "948b6590-9205-499e-a134-395d1a940d43", "userotow@gmail.com", "کاربر دو", "userotow@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "FullName", "UserName" },
                values: new object[] { "7b902044-ab75-450e-88d6-9f2c0350a911", "userothree@gmail.com", "کاربر سه", "userothree@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Email", "FullName", "UserName" },
                values: new object[] { "d7d17b08-cd36-4ca2-90a4-deee957e83eb", "userofour@gmail.com", "کاربر چهار", "userfour@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 11, 22, 10, 41, 369, DateTimeKind.Local).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 11, 22, 10, 41, 369, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 11, 22, 10, 41, 369, DateTimeKind.Local).AddTicks(903));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "InsertTime", "RemoveTime", "TotalSiteCommissionAmounts", "UpdateTime" },
                values: new object[] { 2, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber" },
                values: new object[] { "d68c4e09-5433-4967-92b9-36446ad22e40", "1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "FullName", "UserName" },
                values: new object[] { "b5a54f08-46d9-4875-970c-8ff100022cb9", "admin@gmail.com", "Admin", "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "FullName", "UserName" },
                values: new object[] { "3d03150a-47de-42b9-9f5a-d1aaebb1720e", "userotow@gmail.com", "کاربر دو", "userotow@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Email", "FullName", "UserName" },
                values: new object[] { "dde16c10-a6a1-4e32-9afb-c9aad869189c", "userothree@gmail.com", "کاربر سه", "userothree@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 11, 21, 56, 4, 163, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 11, 21, 56, 4, 163, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 11, 21, 56, 4, 163, DateTimeKind.Local).AddTicks(4182));
        }
    }
}
