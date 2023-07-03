using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class top : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "دسته بندی تکنولوژی شامل تجهیزات رایانه، فناوری اطلاعات و ارتباطات، شبکه‌ها و سیستم‌های مرتبط با فناوری اطلاعات، ابزارهای الکترونیکی و دستگاه‌های هوشمند است. این دسته بندی شامل سخت‌افزار، نرم‌افزار، دستگاه‌های مخابراتی، تجهیزات شبکه، ابزارهای الکترونیکی خانگی و همچنین دستگاه‌های هوشمند مثل تلفن هوشمند، تلویزیون هوشمند، ساعت هوشمند و دستگاه‌های دیگر می‌باشد.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "دسته بندی موسیقی شامل انواع سازها، آلات موسیقی، تجهیزات ضبط و پخش صوت و همچنین تابلوهای نقاشی مرتبط با هنر موسیقی و تجسم می‌باشد. این دسته بندی شامل سازهای مختلف موسیقی مانند پیانو، گیتار، ویولن، درامز و آلات بادی است. همچنین شامل تجهیزات ضبط و پخش صوتی مثل میکروفون، هدفون، اسپیکر و دستگاه‌های مرتبط با پخش صوت می‌باشد. تابلوهای نقاشی موسیقی نیز می‌توانند شامل تصاویری از سازها و هنرمندان موسیقی باشند.", "موسیقی" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "دسته بندی لوازم منزل شامل همه‌ی لوازم مورد نیاز در منزل است. این شامل لوازم خانگی مانند یخچال، ماشین لباسشویی، تلویزیون، اجاق گاز و هود می‌شود. همچنین دسته بندی لوازم منزل شامل لوازم دکوراسیونی مانند مبلمان، کمد، میز و صندلی، لوازم آشپزخانه مانند قابلمه، ظرف‌های پخت و پز و ابزارآلات آشپزخانه نیز می‌شود. این دسته بندی همچنین می‌تواند شامل لوازم تزئینی، لوازم بهداشتی و دیگر لوازم مرتبط با منزل باشد.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "دسته بندی نقاشی شامل کالاهایی است که در دسته بندی‌های بالا موجود نیستند و به هنر نقاشی و تجسم مرتبط می‌شوند. این شامل تابلوهای نقاشی با موضوعات مختلف می‌شود که توسط هنرمندان نقاش تولید می‌شوند. تابلوهای نقاشی می‌توانند شامل مناظر طبیعی، پرتره‌ها، طرح‌ها و هنرهای تجسمی دیگر باشند. این دسته بندی نیز شامل اثرهای هنری و اشیاء مجسمه‌سازی شده است.", "نقاشی" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "InsertTime", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { 5, "دسته بندی عتیقه شامل کالاهایی است که در دسته بندی‌های بالا موجود نیستند و به عنوان اشیاء قدیمی و قابل ارزش تشخیص داده می‌شوند. این شامل قطعات تاریخی، آثار هنری قدیمی، سکه‌های باستانی، جواهرات و سایر اشیاء تاریخی و باستانی می‌شود. این دسته بندی معمولاً جهت جمع‌آوری و نمایش قطعات تاریخی و همچنین معاملات مرتبط با عتیقه استفاده می‌شود.", null, "عتیقه", null, null },
                    { 6, "دسته بندی فرهنگی شامل کالاهایی است که در دسته بندی‌های بالا موجود نیستند و با موضوعات فرهنگی و هنری مرتبط هستند. این شامل کتاب‌ها، مجلات، فیلم‌ها، موسیقی، نمایش‌های تئاتر و سایر رسانه‌ها و فعالیت‌های هنری و فرهنگی می‌شود. این دسته بندی برای نمایش و فروش محصولات فرهنگی و هنری استفاده می‌شود و می‌تواند شامل اثار هنری، کتاب‌های ادبی و تخصصی، موسیقی‌های متن فیلم، نمایش‌های تئاتر و دیگر فعالیت‌های هنری و فرهنگی باشد.", null, "فرهنگی", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 7, 3, 3, 55, 54, 96, DateTimeKind.Local).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 7, 3, 3, 55, 54, 96, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 7, 3, 3, 55, 54, 96, DateTimeKind.Local).AddTicks(9554));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "InsertTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RemoveTime", "SecurityStamp", "TwoFactorEnabled", "UpdateTime", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a101513c-84f9-4b8f-a1c9-a7c39cf41e4b", "userone@gmail.com", false, "کاربر یک", null, false, null, null, null, null, null, false, null, null, false, null, "userone@gmail.com" },
                    { 2, 0, "9f4cb459-41de-4dcd-9c62-c32bf78fa1d1", "userotow@gmail.com", false, "کاربر دو", null, false, null, null, null, null, null, false, null, null, false, null, "userotow@gmail.com" },
                    { 3, 0, "0e9313f0-c078-49a7-b64e-33dbbb699b3d", "userothree@gmail.com", false, "کاربر سه", null, false, null, null, null, null, null, false, null, null, false, null, "userothree@gmail.com" },
                    { 4, 0, "27dcff0e-cbe8-4733-ae44-6d22653eecd9", "userofour@gmail.com", false, "کاربر چهار", null, false, null, null, null, null, null, false, null, null, false, null, "userfour@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "تجهیزات رایانه ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "انواع ساز و تابلو های نقاشی", "هنری" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "همه ی لوازم مورد نیاز در منزل");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "شامل همه ی کالاهایی که در دسته باندی بالا موجود نیست.", "سایر" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 30, 2, 14, 54, 316, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 30, 2, 14, 54, 316, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 6, 30, 2, 14, 54, 316, DateTimeKind.Local).AddTicks(5741));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Availability", "BasePrice", "BidId", "BoothId", "Description", "InsertTime", "IsActive", "IsAuction", "IsConfirm", "IsRemove", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, 10, 5000000, null, null, "لپ تاپ جدید و بسیار کارآمد", null, true, false, null, false, "لپ تاپ", null, null },
                    { 2, 5, 2000000, null, null, "گوشی هوشمند با قابلیت‌های فراوان", null, true, false, null, false, "گوشی هوشمند", null, null },
                    { 20, 50, 100000, null, null, "بهترین کتاب برای یادگیری برنامه‌نویسی", null, true, false, null, false, "کتاب برنامه نویسی", null, null }
                });
        }
    }
}
