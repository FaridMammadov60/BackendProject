using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BackEndProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserCreateTime = table.Column<DateTime>(nullable: true),
                    UserDeletedTime = table.Column<DateTime>(nullable: true),
                    UserUpdateTime = table.Column<DateTime>(nullable: true),
                    ConfirmMailTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    Support = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WorkTime = table.Column<string>(nullable: true),
                    AmerikanExpress = table.Column<string>(nullable: true),
                    MasterCard = table.Column<string>(nullable: true),
                    PayPal = table.Column<string>(nullable: true),
                    Discover = table.Column<string>(nullable: true),
                    Visa = table.Column<string>(nullable: true),
                    Google = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    DeleteAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    DeleteAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SaledAt = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    BestSeller = table.Column<bool>(nullable: false),
                    NewArrivle = table.Column<bool>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    StockCount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DisCountPrice = table.Column<double>(nullable: false),
                    TaxPrecent = table.Column<double>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    DeleteAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(nullable: true),
                    ProductId1 = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserId1 = table.Column<int>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketItems_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsMain = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "banner-1.png" },
                    { 2, "banner-2.png" }
                });

            migrationBuilder.InsertData(
                table: "Bios",
                columns: new[] { "Id", "AmerikanExpress", "Discover", "Email", "Facebook", "Google", "ImageUrl", "Instagram", "Linkedin", "Location", "MasterCard", "PayPal", "Phone", "Support", "Visa", "WorkTime" },
                values: new object[] { 1, "", "", "Faridmma@code.edu.az", "https://www.facebook.com", "https://www.google.com", "logo.png", "https://www.instagram.com", "https://www.linkedin.com", "Bizim mehle Ordubad, 085 NMR AZE", "", "", "+994 50 671 99 99", "24/7 Support", "", "Mon-Sat 9:00pm - 5:00pm Sun:Closed" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "ImageUrl", "IsDeleted", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, null, null, "brand-1.jpg", false, "Apple", null },
                    { 2, null, null, "brand-2.jpg", false, "Samsung", null },
                    { 3, null, null, "brand-3.jpg", false, "Lenova", null },
                    { 4, null, null, "brand-4.jpg", false, "HP", null },
                    { 5, null, null, "brand-5.jpg", false, "Nike", null },
                    { 6, null, null, "brand-6.jpg", false, "Adidas", null },
                    { 7, null, null, "brand-6.jpg", false, "Sirab", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "ImageUrl", "IsDeleted", "Name", "ParentId", "UpdateAt" },
                values: new object[,]
                {
                    { 7, null, null, "category-5.jpg", false, "Dress", null, null },
                    { 6, null, null, "category-11.jpg", false, "Accessories", null, null },
                    { 5, null, null, "category-2.jpg", false, "TV Audio", null, null },
                    { 4, null, null, "category-12.jpg", false, "Electronic", null, null },
                    { 3, null, null, "category-4.jpg", false, "Game Consoles", null, null },
                    { 2, null, null, "category-3.jpg", false, "SmartPhone", null, null },
                    { 1, null, null, "category-1.jpg", false, "Computer", null, null }
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
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tag1" },
                    { 2, "Tag2" },
                    { 3, "Tag3" },
                    { 4, "Tag4" },
                    { 5, "Tag5" },
                    { 6, "Tag6" },
                    { 7, "Tag7" },
                    { 8, "Tag8" },
                    { 9, "Tag9" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "ImageUrl", "IsDeleted", "Name", "ParentId", "UpdateAt" },
                values: new object[,]
                {
                    { 8, null, null, "category-1.jpg", false, "Laptop", 1, null },
                    { 21, null, null, "category-12.jpg", false, "Paltar", 7, null },
                    { 20, null, null, "category-11.jpg", false, "Kabro", 6, null },
                    { 19, null, null, "category-11.jpg", false, "Air Drop", 6, null },
                    { 18, null, null, "category-10.jpg", false, "Camera", 5, null },
                    { 17, null, null, "category-2.jpg", false, "Smart TV", 5, null },
                    { 16, null, null, "category-11.jpg", false, "Air Drop", 4, null },
                    { 15, null, null, "category-12.jpg", false, "Adabter", 4, null },
                    { 13, null, null, "category-4.jpg", false, "XBOX", 3, null },
                    { 12, null, null, "category-4.jpg", false, "PS", 3, null },
                    { 11, null, null, "category-3.jpg", false, "IOS", 2, null },
                    { 10, null, null, "category-3.jpg", false, "Android", 2, null },
                    { 9, null, null, "category-1.jpg", false, "DesktopCopmuter", 1, null },
                    { 14, null, null, "category-9.jpg", false, "Paltaryuyan", 4, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BestSeller", "BrandId", "CategoryId", "CreateAt", "DeleteAt", "Desc", "DisCountPrice", "InStock", "IsDeleted", "IsFeatured", "Name", "NewArrivle", "Price", "StockCount", "TaxPrecent", "Title", "UpdateAt" },
                values: new object[] { 6, false, 1, 1, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, true, "Comp", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null });

            migrationBuilder.InsertData(
                table: "SliderContents",
                columns: new[] { "Id", "Desc", "Name", "Offer", "SliderId", "Title" },
                values: new object[,]
                {
                    { 1, "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "Fulldive VR.", "Save $120 when you buy", 1, "2020 Virtual Reality" },
                    { 2, "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "Sony Bravia.", "Save $120 when you buy", 2, "4K HDR Smart TV 43" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsMain", "ProductId" },
                values: new object[,]
                {
                    { 23, "product-9.jpg", false, 6 },
                    { 6, "product-6.jpg", false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BestSeller", "BrandId", "CategoryId", "CreateAt", "DeleteAt", "Desc", "DisCountPrice", "InStock", "IsDeleted", "IsFeatured", "Name", "NewArrivle", "Price", "StockCount", "TaxPrecent", "Title", "UpdateAt" },
                values: new object[,]
                {
                    { 1, true, 1, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 170.0, true, false, false, "MacBook Pro 6", true, 180.0, 35, 5.0, "Lorem ipsum dolor sit amet", null },
                    { 9, false, 1, 11, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, false, "Iphone 11 ProMax", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null },
                    { 8, false, 1, 11, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, false, "Iphone 11 Pro", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null },
                    { 7, false, 1, 11, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, false, "Iphone 12", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null },
                    { 5, false, 1, 11, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, false, "Iphone 13 Pro", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null },
                    { 10, true, 1, 11, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, true, "Iphone 12 ProMax", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null },
                    { 15, true, 3, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 580.0, true, false, true, "Lenova YOGA x", false, 690.0, 35, 8.0, "Lorem ipsum dolor sit amet", null },
                    { 13, true, 3, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 580.0, true, false, true, "Lenova YOGA", false, 690.0, 35, 8.0, "Lorem ipsum dolor sit amet", null },
                    { 12, true, 3, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 580.0, true, false, true, "Lenova IDPAD", false, 690.0, 35, 8.0, "Lorem ipsum dolor sit amet", null },
                    { 11, true, 3, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 580.0, true, false, true, "Lenova THINKPAD x", false, 690.0, 35, 8.0, "Lorem ipsum dolor sit amet", null },
                    { 4, false, 2, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, true, "Samsung s22 ultra", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null },
                    { 3, true, 3, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, true, "Lenova Thinkpad", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null },
                    { 2, true, 2, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 80.0, true, false, true, "Samsung COMP", true, 90.0, 35, 5.0, "Lorem ipsum dolor sit amet", null },
                    { 14, true, 3, 8, null, null, "Lorem ipsum dolor sit amet, consecte", 580.0, true, false, true, "Lenova YOGA x", false, 690.0, 35, 8.0, "Lorem ipsum dolor sit amet", null },
                    { 16, false, 1, 11, null, null, "Lorem ipsum dolor sit amet, consecte", 180.0, true, false, true, "Iphone 12 Pro", true, 190.0, 35, 7.0, "Lorem ipsum dolor sit amet", null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsMain", "ProductId" },
                values: new object[,]
                {
                    { 1, "product-1.jpg", true, 1 },
                    { 26, "product-9.jpg", false, 9 },
                    { 9, "product-9.jpg", false, 9 },
                    { 25, "product-12.jpg", false, 8 },
                    { 8, "product-8.jpg", false, 8 },
                    { 24, "product-12.jpg", false, 7 },
                    { 7, "product-7.jpg", false, 7 },
                    { 22, "product-12.jpg", false, 5 },
                    { 5, "product-5.jpg", true, 5 },
                    { 17, "product-17.jpg", false, 15 },
                    { 16, "product-16.jpg", false, 15 },
                    { 15, "product-15.jpg", false, 15 },
                    { 14, "product-14.jpg", false, 14 },
                    { 10, "product-10.jpg", false, 10 },
                    { 13, "product-13.jpg", false, 13 },
                    { 11, "product-11.jpg", false, 11 },
                    { 21, "product-9.jpg", false, 4 },
                    { 4, "product-4.jpg", true, 4 },
                    { 20, "product-10.jpg", false, 3 },
                    { 3, "product-3.jpg", true, 3 },
                    { 19, "product-10.jpg", false, 2 },
                    { 2, "product-2.jpg", true, 2 },
                    { 18, "product-10.jpg", false, 1 },
                    { 12, "product-12.jpg", false, 12 },
                    { 27, "product-12.jpg", false, 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "Id", "ProductId", "TagId" },
                values: new object[,]
                {
                    { 5, 4, 5 },
                    { 4, 3, 4 },
                    { 6, 5, 5 },
                    { 3, 2, 3 },
                    { 2, 1, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_AppUserId",
                table: "BasketItems",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId1",
                table: "BasketItems",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_UserId1",
                table: "BasketItems",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_ProductId",
                table: "ProductTags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SliderContents_SliderId",
                table: "SliderContents",
                column: "SliderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Bios");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "SliderContents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
