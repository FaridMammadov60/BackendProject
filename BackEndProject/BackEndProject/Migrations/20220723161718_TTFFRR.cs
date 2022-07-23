using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class TTFFRR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ImageUrl", "ParentId" },
                values: new object[] { "category-11.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ImageUrl", "ParentId" },
                values: new object[] { "category-10.jpg", 3 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "ImageUrl", "Name", "ParentId", "UpdateAt" },
                values: new object[,]
                {
                    { 26, null, null, "category-7.jpg", "DesktopComputer", 2, null },
                    { 27, null, null, "category-7.jpg", "PS4", 4, null },
                    { 28, null, null, "category-7.jpg", "Electronic TT", 5, null },
                    { 29, null, null, "category-2.jpg", "TV Samsung S3", 6, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ImageUrl", "ParentId" },
                values: new object[] { "category-9.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ImageUrl", "ParentId" },
                values: new object[] { "category-9.jpg", 2 });
        }
    }
}
