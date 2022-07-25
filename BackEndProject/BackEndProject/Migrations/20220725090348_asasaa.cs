using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class asasaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductId",
                value: 13);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BestSeller", "BrandId", "CategoryId", "CreateAt", "DeleteAt", "Desc", "DisCountPrice", "InStock", "IsFeatured", "Name", "NewArrivle", "Price", "StockCount", "TaxPrecent", "Title", "UpdateAt" },
                values: new object[,]
                {
                    { 14, true, 3, 15, null, null, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 580.0, true, true, "Lenova YOGA x", false, 690.0, 35, 8.0, "Lorem ipsum dolor sit amet", null },
                    { 15, true, 3, 15, null, null, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 580.0, true, true, "Lenova YOGA x", false, 690.0, 35, 8.0, "Lorem ipsum dolor sit amet", null }
                });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductId",
                value: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductId",
                value: 6);

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsMain", "ProductId" },
                values: new object[,]
                {
                    { 15, "product-15.jpg", false, 8 },
                    { 14, "product-14.jpg", false, 7 },
                    { 16, "product-16.jpg", false, 9 },
                    { 17, "product-17.jpg", false, 10 }
                });
        }
    }
}
