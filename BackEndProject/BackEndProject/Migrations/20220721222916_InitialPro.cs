using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class InitialPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    DisCountPrice = table.Column<double>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Availability = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SliderContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Offer = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    SliderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SliderContents_Sliders_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Sliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mens" },
                    { 2, "Womens" },
                    { 3, "Sports" },
                    { 4, "Fabric" },
                    { 5, "Leather" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "slider-1.jpg" },
                    { 2, "slider-2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "Count", "Desc", "DisCountPrice", "ImageUrl", "Name", "Price", "Title" },
                values: new object[,]
                {
                    { 1, true, 1, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 70.0, "product-1.jpg", "Primitive Mens Premium Shoes", 80.0, "Lorem ipsum dolor sit amet" },
                    { 6, true, 1, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 80.0, "product-6.jpg", "Primitive Mens Premium Shoes", 90.0, "Lorem ipsum dolor sit amet" },
                    { 2, true, 2, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 80.0, "product-2.jpg", "Quickin Womans Premium Shoes", 90.0, "Lorem ipsum dolor sit amet" },
                    { 7, true, 2, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 40.0, "product-7.jpg", "Primitive Womans Premium Shoes", 50.0, "Lorem ipsum dolor sit amet" },
                    { 11, true, 2, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 40.0, "product-11.jpg", "Primitive Womans Premium Shoes", 50.0, "Lorem ipsum dolor sit amet" },
                    { 3, true, 3, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 40.0, "product-3.jpg", "Rexpo Sports Premium Shoes", 50.0, "Lorem ipsum dolor sit amet" },
                    { 8, true, 3, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 70.0, "product-8.jpg", "Primitive Sports Premium Shoes", 75.0, "Lorem ipsum dolor sit amet" },
                    { 12, true, 3, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 70.0, "product-12.jpg", "Primitive Sports Premium Shoes", 75.0, "Lorem ipsum dolor sit amet" },
                    { 4, true, 4, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 70.0, "product-4.jpg", "Primitive Fabric Premium Shoes", 75.0, "Lorem ipsum dolor sit amet" },
                    { 9, true, 4, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 30.0, "product-9.jpg", "Primitive Fabric Premium Shoes", 40.0, "Lorem ipsum dolor sit amet" },
                    { 5, true, 5, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 30.0, "product-5.jpg", "Primitive Leather slipper", 40.0, "Lorem ipsum dolor sit amet" },
                    { 10, true, 5, 35, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", 80.0, "product-10.jpg", "Primitive Leather Premium Shoes", 90.0, "Lorem ipsum dolor sit amet" }
                });

            migrationBuilder.InsertData(
                table: "SliderContents",
                columns: new[] { "Id", "Desc", "Name", "Offer", "SliderId", "Title" },
                values: new object[,]
                {
                    { 1, "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "Fulldive VR.", "Save $120 when you buy", 1, "2020 Virtual Reality" },
                    { 2, "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "Sony Bravia.", "Save $120 when you buy", 2, "4K HDR Smart TV 43" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SliderContents_SliderId",
                table: "SliderContents",
                column: "SliderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SliderContents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
