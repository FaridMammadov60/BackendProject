using BackEndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    ImageUrl = "slider-1.jpg"
                },
                new Slider
                {
                    Id = 2,
                    ImageUrl = "slider-2.jpg"

                }
            );
            modelBuilder.Entity<SliderContent>().HasData(
              new SliderContent
              {
                  Id = 1,
                  Name = "Fulldive VR.",
                  SliderId = 1,
                  Offer = "Save $120 when you buy",
                  Title = "2020 Virtual Reality",
                  Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"

              },
              new SliderContent
              {
                  Id = 2,
                  Name = "Sony Bravia.",
                  SliderId = 2,
                  Offer = "Save $120 when you buy",
                  Title = "4K HDR Smart TV 43",
                  Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"

              }
          );
            modelBuilder.Entity<Banner>().HasData(
             new Banner
             {
                 Id = 1,
                 ImageUrl = "banner-1.png",

             },
             new Banner
             {
                 Id = 2,
                 ImageUrl = "banner-2.png",

             }
         );
            modelBuilder.Entity<Bio>().HasData(
            new Bio
            {
                Id = 1,
                ImageUrl = "logo.png",
                Support = "24/7 Support",
                Location = "Bizim mehle Ordubad, 085 NMR AZE",
                Phone = "+994 50 671 99 99",
                Email = "Faridmma@code.edu.az",
                WorkTime = "Mon-Sat 9:00pm - 5:00pm Sun:Closed",
                AmerikanExpress = "",
                MasterCard = "",
                PayPal = "",
                Discover = "",
                Visa = "",
                Google = "https://www.google.com",
                Instagram = "https://www.instagram.com",
                Linkedin = "https://www.linkedin.com",
                Facebook = "https://www.facebook.com"

            }
        );
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Computer",
                   ImageUrl = "category-1.jpg"
               },
               new Category
               {
                   Id = 2,
                   Name = "SmartPhone",
                   ImageUrl = "category-3.jpg"
               },
                new Category
                {
                    Id = 3,
                    Name = "Game Consoles",
                    ImageUrl = "category-4.jpg"
                },
               new Category
               {
                   Id = 4,
                   Name = "Electronic",
                   ImageUrl = "category-12.jpg"
               },
               new Category
               {
                   Id = 5,
                   Name = "TV Audio",
                   ImageUrl = "category-2.jpg"
               },
               new Category
               {
                   Id = 6,
                   Name = "Accessories",
                   ImageUrl = "category-11.jpg"
               },
                new Category
                {
                    Id = 7,
                    Name = "Dress",
                    ImageUrl = "category-5.jpg"
                },
                new Category
                {
                    Id = 8,
                    Name = "Laptop",
                    ImageUrl = "category-1.jpg",
                    ParentId = 1
                },
               new Category
               {
                   Id = 9,
                   Name = "DesktopCopmuter",
                   ImageUrl = "category-1.jpg",
                   ParentId = 1
               },
                new Category
                {
                    Id = 10,
                    Name = "Android",
                    ImageUrl = "category-3.jpg",
                    ParentId = 2
                },
               new Category
               {
                   Id = 11,
                   Name = "IOS",
                   ImageUrl = "category-3.jpg",
                   ParentId = 2
               },
                new Category
                {
                    Id = 12,
                    Name = "PS",
                    ImageUrl = "category-4.jpg",
                    ParentId = 3
                },
                new Category
                {
                    Id = 13,
                    Name = "XBOX",
                    ImageUrl = "category-4.jpg",
                    ParentId = 3
                },
                new Category
                {
                    Id = 14,
                    Name = "Paltaryuyan",
                    ImageUrl = "category-9.jpg",
                    ParentId = 4
                },
                new Category
                {
                    Id = 15,
                    Name = "Adabter",
                    ImageUrl = "category-12.jpg",
                    ParentId = 4
                },
                  new Category
                  {
                      Id = 16,
                      Name = "Air Drop",
                      ImageUrl = "category-11.jpg",
                      ParentId = 4
                  },
                new Category
                {
                    Id = 17,
                    Name = "Smart TV",
                    ParentId = 5,
                    ImageUrl = "category-2.jpg",
                },
                new Category
                {
                    Id = 18,
                    Name = "Camera",
                    ParentId = 5,
                    ImageUrl = "category-10.jpg",
                },
                new Category
                {
                    Id = 19,
                    Name = "Air Drop",
                    ParentId = 6,
                    ImageUrl = "category-11.jpg",
                },
                new Category
                {
                    Id = 20,
                    Name = "Kabro",
                    ParentId = 6,
                    ImageUrl = "category-11.jpg",
                },
                new Category
                {
                    Id = 21,
                    Name = "Paltar",
                    ParentId = 7,
                    ImageUrl = "category-12.jpg",
                }
           );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "MacBook Pro 6",
                    CategoryId = 8,
                    BrandId = 1,
                    StockCount = 35,
                    Price = 180.00,
                    DisCountPrice = 170.00,
                    TaxPrecent = 5.00,
                    InStock = true,
                    NewArrivle = true,
                    BestSeller = true,
                    IsFeatured = false,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consecte",

                },
                new Product
                {
                    Id = 2,
                    Name = "Samsung COMP",
                    CategoryId = 8,
                    BrandId = 2,
                    StockCount = 35,
                    Price = 90.00,
                    DisCountPrice = 80.00,
                    TaxPrecent = 5.00,
                    InStock = true,
                    NewArrivle = true,
                    BestSeller = true,
                    IsFeatured = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consecte",

                },
                 new Product
                 {
                     Id = 3,
                     Name = "Lenova Thinkpad",
                     CategoryId = 8,
                     BrandId = 3,
                     StockCount = 35,
                     Price = 190.00,
                     DisCountPrice = 180.00,
                     TaxPrecent = 7.00,
                     InStock = true,
                     NewArrivle = true,
                     BestSeller = true,
                     IsFeatured = true,
                     Title = "Lorem ipsum dolor sit amet",
                     Desc = "Lorem ipsum dolor sit amet, consecte",

                 }
                 ,
                 new Product
                 {
                     Id = 4,
                     Name = "Samsung s22 ultra",
                     CategoryId = 8,
                     BrandId = 2,
                     StockCount = 35,
                     Price = 190.00,
                     DisCountPrice = 180.00,
                     TaxPrecent = 7.00,
                     InStock = true,
                     NewArrivle = true,
                     BestSeller = false,
                     IsFeatured = true,
                     Title = "Lorem ipsum dolor sit amet",
                     Desc = "Lorem ipsum dolor sit amet, consecte",

                 },
                 new Product
                 {
                     Id = 5,
                     Name = "Iphone 13 Pro",
                     CategoryId = 11,
                     BrandId = 1,
                     StockCount = 35,
                     Price = 190.00,
                     DisCountPrice = 180.00,
                     TaxPrecent = 7.00,
                     InStock = true,
                     NewArrivle = true,
                     BestSeller = false,
                     IsFeatured = false,
                     Title = "Lorem ipsum dolor sit amet",
                     Desc = "Lorem ipsum dolor sit amet, consecte",

                 },
                 new Product
                 {
                     Id = 6,
                     Name = "Comp",
                     CategoryId = 1,
                     BrandId = 1,
                     StockCount = 35,
                     Price = 190.00,
                     DisCountPrice = 180.00,
                     TaxPrecent = 7.00,
                     InStock = true,
                     NewArrivle = true,
                     BestSeller = false,
                     IsFeatured = true,
                     Title = "Lorem ipsum dolor sit amet",
                     Desc = "Lorem ipsum dolor sit amet, consecte",

                 },
                  new Product
                  {
                      Id = 7,
                      Name = "Iphone 12",
                      CategoryId = 11,
                      BrandId = 1,
                      StockCount = 35,
                      Price = 190.00,
                      DisCountPrice = 180.00,
                      TaxPrecent = 7.00,
                      InStock = true,
                      NewArrivle = true,
                      BestSeller = false,
                      IsFeatured = false,
                      Title = "Lorem ipsum dolor sit amet",
                      Desc = "Lorem ipsum dolor sit amet, consecte",

                  },
                  new Product
                  {
                      Id = 8,
                      Name = "Iphone 11 Pro",
                      CategoryId = 11,
                      BrandId = 1,
                      StockCount = 35,
                      Price = 190.00,
                      DisCountPrice = 180.00,
                      TaxPrecent = 7.00,
                      InStock = true,
                      NewArrivle = true,
                      BestSeller = false,
                      IsFeatured = false,
                      Title = "Lorem ipsum dolor sit amet",
                      Desc = "Lorem ipsum dolor sit amet, consecte",

                  },
                  new Product
                  {
                      Id = 9,
                      Name = "Iphone 11 ProMax",
                      CategoryId = 11,
                      BrandId = 1,
                      StockCount = 35,
                      Price = 190.00,
                      DisCountPrice = 180.00,
                      TaxPrecent = 7.00,
                      InStock = true,
                      NewArrivle = true,
                      BestSeller = false,
                      IsFeatured = false,
                      Title = "Lorem ipsum dolor sit amet",
                      Desc = "Lorem ipsum dolor sit amet, consecte",

                  },
                  new Product
                  {
                      Id = 10,
                      Name = "Iphone 12 ProMax",
                      CategoryId = 11,
                      BrandId = 1,
                      StockCount = 35,
                      Price = 190.00,
                      DisCountPrice = 180.00,
                      TaxPrecent = 7.00,
                      InStock = true,
                      NewArrivle = true,
                      BestSeller = true,
                      IsFeatured = true,
                      Title = "Lorem ipsum dolor sit amet",
                      Desc = "Lorem ipsum dolor sit amet, consecte",

                  },
                  new Product
                  {
                      Id = 11,
                      Name = "Lenova THINKPAD x",
                      CategoryId = 8,
                      BrandId = 3,
                      StockCount = 35,
                      Price = 690.00,
                      DisCountPrice = 580.00,
                      TaxPrecent = 8.00,
                      InStock = true,
                      NewArrivle = false,
                      BestSeller = true,
                      IsFeatured = true,
                      Title = "Lorem ipsum dolor sit amet",
                      Desc = "Lorem ipsum dolor sit amet, consecte",

                  },
                  new Product
                  {
                      Id = 12,
                      Name = "Lenova IDPAD",
                      CategoryId = 8,
                      BrandId = 3,
                      StockCount = 35,
                      Price = 690.00,
                      DisCountPrice = 580.00,
                      TaxPrecent = 8.00,
                      InStock = true,
                      NewArrivle = false,
                      BestSeller = true,
                      IsFeatured = true,
                      Title = "Lorem ipsum dolor sit amet",
                      Desc = "Lorem ipsum dolor sit amet, consecte",

                  },
                  new Product
                  {
                      Id = 13,
                      Name = "Lenova YOGA",
                      CategoryId = 8,
                      BrandId = 3,
                      StockCount = 35,
                      Price = 690.00,
                      DisCountPrice = 580.00,
                      TaxPrecent = 8.00,
                      InStock = true,
                      NewArrivle = false,
                      BestSeller = true,
                      IsFeatured = true,
                      Title = "Lorem ipsum dolor sit amet",
                      Desc = "Lorem ipsum dolor sit amet, consecte",

                  },
                    new Product
                    {
                        Id = 14,
                        Name = "Lenova YOGA x",
                        CategoryId = 8,
                        BrandId = 3,
                        StockCount = 35,
                        Price = 690.00,
                        DisCountPrice = 580.00,
                        TaxPrecent = 8.00,
                        InStock = true,
                        NewArrivle = false,
                        BestSeller = true,
                        IsFeatured = true,
                        Title = "Lorem ipsum dolor sit amet",
                        Desc = "Lorem ipsum dolor sit amet, consecte",

                    },
                     new Product
                     {
                         Id = 15,
                         Name = "Lenova YOGA x",
                         CategoryId = 8,
                         BrandId = 3,
                         StockCount = 35,
                         Price = 690.00,
                         DisCountPrice = 580.00,
                         TaxPrecent = 8.00,
                         InStock = true,
                         NewArrivle = false,
                         BestSeller = true,
                         IsFeatured = true,
                         Title = "Lorem ipsum dolor sit amet",
                         Desc = "Lorem ipsum dolor sit amet, consecte",

                     },
                         new Product
                         {
                             Id = 16,
                             Name = "Iphone 12 Pro",
                             CategoryId = 11,
                             BrandId = 1,
                             StockCount = 35,
                             Price = 190.00,
                             DisCountPrice = 180.00,
                             TaxPrecent = 7.00,
                             InStock = true,
                             NewArrivle = true,
                             BestSeller = false,
                             IsFeatured = true,
                             Title = "Lorem ipsum dolor sit amet",
                             Desc = "Lorem ipsum dolor sit amet, consecte",

                         }
                );
            modelBuilder.Entity<Brand>().HasData(
              new Brand
              {
                  Id = 1,
                  Name = "Apple",
                  ImageUrl = "brand-1.jpg"
              },
              new Brand
              {
                  Id = 2,
                  Name = "Samsung",
                  ImageUrl = "brand-2.jpg"
              },
               new Brand
               {
                   Id = 3,
                   Name = "Lenova",
                   ImageUrl = "brand-3.jpg"
               },
               new Brand
               {
                   Id = 4,
                   Name = "HP",
                   ImageUrl = "brand-4.jpg"
               },
                new Brand
                {
                    Id = 5,
                    Name = "Nike",
                    ImageUrl = "brand-5.jpg"
                },
                new Brand
                {
                    Id = 6,
                    Name = "Adidas",
                    ImageUrl = "brand-6.jpg"
                },
                new Brand
                {
                    Id = 7,
                    Name = "Sirab",
                    ImageUrl = "brand-6.jpg"
                }
              );
            modelBuilder.Entity<ProductImage>().HasData(
             new ProductImage
             {
                 Id = 1,
                 ImageUrl = "product-1.jpg",
                 IsMain = true,
                 ProductId = 1
             },
             new ProductImage
             {
                 Id = 2,
                 ImageUrl = "product-2.jpg",
                 IsMain = true,
                 ProductId = 2
             },
              new ProductImage
              {
                  Id = 3,
                  ImageUrl = "product-3.jpg",
                  IsMain = true,
                  ProductId = 3
              },
              new ProductImage
              {
                  Id = 4,
                  ImageUrl = "product-4.jpg",
                  IsMain = true,
                  ProductId = 4
              },
              new ProductImage
              {
                  Id = 5,
                  ImageUrl = "product-5.jpg",
                  IsMain = true,
                  ProductId = 5
              },
             new ProductImage
             {
                 Id = 6,
                 ImageUrl = "product-6.jpg",
                 ProductId = 6
             },
              new ProductImage
              {
                  Id = 7,
                  ImageUrl = "product-7.jpg",
                  ProductId = 7
              },
              new ProductImage
              {
                  Id = 8,
                  ImageUrl = "product-8.jpg",
                  ProductId = 8
              },
              new ProductImage
              {
                  Id = 9,
                  ImageUrl = "product-9.jpg",
                  ProductId = 9
              },
               new ProductImage
               {
                   Id = 10,
                   ImageUrl = "product-10.jpg",
                   ProductId = 10
               },
               new ProductImage
               {
                   Id = 11,
                   ImageUrl = "product-11.jpg",
                   ProductId = 11
               },
             new ProductImage
             {
                 Id = 12,
                 ImageUrl = "product-12.jpg",
                 ProductId = 12
             },
              new ProductImage
              {
                  Id = 13,
                  ImageUrl = "product-13.jpg",
                  ProductId = 13
              },
              new ProductImage
              {
                  Id = 14,
                  ImageUrl = "product-14.jpg",
                  ProductId = 14
              },
              new ProductImage
              {
                  Id = 15,
                  ImageUrl = "product-15.jpg",
                  ProductId = 15
              },
             new ProductImage
             {
                 Id = 16,
                 ImageUrl = "product-16.jpg",
                 ProductId = 15
             },
              new ProductImage
              {
                  Id = 17,
                  ImageUrl = "product-17.jpg",
                  ProductId = 15
              },
              new ProductImage
              {
                  Id = 18,
                  ImageUrl = "product-10.jpg",
                  ProductId = 1
              },
              new ProductImage
              {
                  Id = 19,
                  ImageUrl = "product-10.jpg",
                  ProductId = 2
              },
              new ProductImage
              {
                  Id = 20,
                  ImageUrl = "product-10.jpg",
                  ProductId = 3
              }
              ,
              new ProductImage
              {
                  Id = 21,
                  ImageUrl = "product-9.jpg",
                  ProductId = 4
              },
              new ProductImage
              {
                  Id = 22,
                  ImageUrl = "product-12.jpg",
                  ProductId = 5
              },
               new ProductImage
               {
                   Id = 23,
                   ImageUrl = "product-9.jpg",
                   ProductId = 6
               },
              new ProductImage
              {
                  Id = 24,
                  ImageUrl = "product-12.jpg",
                  ProductId = 7
              },
              new ProductImage
              {
                  Id = 25,
                  ImageUrl = "product-12.jpg",
                  ProductId = 8
              },
               new ProductImage
               {
                   Id = 26,
                   ImageUrl = "product-9.jpg",
                   ProductId = 9
               },
              new ProductImage
              {
                  Id = 27,
                  ImageUrl = "product-12.jpg",
                  ProductId = 10
              }
             );
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "Tag1"
                },
                new Tag
                {
                    Id = 2,
                    Name = "Tag2"
                },
                new Tag
                {
                    Id = 3,
                    Name = "Tag3"
                },
                new Tag
                {
                    Id = 4,
                    Name = "Tag4"
                },
                new Tag
                {
                    Id = 5,
                    Name = "Tag5"
                }
            );

        }
    }
}
