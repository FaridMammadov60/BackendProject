using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
       // public DbSet<Brand> Brands { get; set; }
        public DbSet<Bio> Bios { get; set; }



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
                Visa = "" ,
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
                   Name = "Laptop",
                   ImageUrl = "category-1.jpg"
               },
               new Category
               {
                   Id = 2,
                   Name = "Computer",
                   ImageUrl = "category-2.jpg"
               },
                new Category
                {
                    Id = 3,
                    Name = "Smartphone",
                    ImageUrl = "category-3.jpg"
                },
               new Category
               {
                   Id = 4,
                   Name = "Game Consoles",
                   ImageUrl = "category-4.jpg"
               },
                new Category
                {
                    Id = 5,
                    Name = "Electronic",
                    ImageUrl = "category-5.jpg"
                },
                new Category
                {
                    Id = 6,
                    Name = "TV",
                    ImageUrl = "category-6.jpg"
                },
                new Category
                {
                    Id = 7,
                    Name = "Audio & Video",
                    ImageUrl = "category-7.jpg"
                },
               new Category
               {
                   Id = 8,
                   Name = "Accessories",
                   ImageUrl = "category-8.jpg"
               },
                new Category
                {
                    Id = 9,
                    Name = "Meiset",
                    ImageUrl = "category-9.jpg"
                },
               new Category
               {
                   Id = 10,
                   Name = "Camera",
                   ImageUrl = "category-10.jpg"
               },
                new Category
                {
                    Id = 11,
                    Name = "Cib saati",
                    ImageUrl = "category-11.jpg"
                },
                new Category
                {
                    Id = 12,
                    Name = "AIR drop",
                    ImageUrl = "category-12.jpg",
                    ParentId = 8
                },
                  new Category
                  {
                      Id = 13,
                      Name = "Hot Categories",
                      ParentId = 1,
                  },
                new Category
                {
                    Id = 14,
                    Name = "OutherWear&Jacket",
                    ParentId = 1,
                },
                new Category
                {
                    Id = 15,
                    Name = "Batteries",
                    ParentId = 9,
                },
                new Category
                {
                    Id = 16,
                    Name = "Chargers",
                    ParentId = 9,
                },
                new Category
                {
                    Id = 17,
                    Name = "Chargers",
                    ParentId = 9,
                },
                new Category
                {
                    Id = 18,
                    Name = "Bags & Cases",
                    ParentId = 9,
                },
                new Category
                {
                    Id = 19,
                    Name = "Electronic Cigarettes",
                    ParentId = 9
                }

           );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Primitive Mens Premium Shoes",
                    CategoryId = 1,
                    //BrandId = 1,
                    StockCount = 35,
                    Price = 80.00,
                    DisCountPrice = 70.00,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 2,
                    Name = "Quickin Womans Premium Shoes",
                    CategoryId = 2,
                    //BrandId = 2,
                    StockCount = 35,
                    Price = 90.00,
                    DisCountPrice = 80.00,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                }
                );
            //modelBuilder.Entity<Brand>().HasData(
            //  new Brand
            //  {
            //      Id = 1,
            //      Name = "Apple"                  
            //  },
            //  new Brand
            //  {
            //      Id = 2,
            //      Name = "Samsung"                  
            //  },
            //   new Brand
            //   {
            //       Id = 2,
            //       Name = "Sony"
            //   }
            //  );
            //     new Product
            //     {
            //         Id = 3,
            //         ImageUrl = "product-3.jpg",
            //         Name = "Rexpo Sports Premium Shoes",
            //         CategoryId = 3,
            //         Count = 35,
            //         Price = 50.00,
            //         DisCountPrice = 40.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     },
            //     new Product
            //     {
            //         Id = 4,
            //         ImageUrl = "product-4.jpg",
            //         Name = "Primitive Fabric Premium Shoes",
            //         CategoryId = 4,
            //         Count = 35,
            //         Price = 75.00,
            //         DisCountPrice = 70.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     },
            //      new Product
            //      {
            //          Id = 5,
            //          ImageUrl = "product-5.jpg",
            //          Name = "Primitive Leather slipper",
            //          CategoryId = 5,
            //          Count = 35,
            //          Price = 40.00,
            //          DisCountPrice = 30.00,
            //          Availability = true,
            //          Title = "Lorem ipsum dolor sit amet",
            //          Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //      },
            //     new Product
            //     {
            //         Id = 6,
            //         ImageUrl = "product-6.jpg",
            //         Name = "Primitive Mens Premium Shoes",
            //         CategoryId = 1,
            //         Count = 35,
            //         Price = 90.00,
            //         DisCountPrice = 80.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     },
            //     new Product
            //     {
            //         Id = 7,
            //         ImageUrl = "product-7.jpg",
            //         Name = "Primitive Womans Premium Shoes",
            //         CategoryId = 2,
            //         Count = 35,
            //         Price = 50.00,
            //         DisCountPrice = 40.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     },
            //     new Product
            //     {
            //         Id = 8,
            //         ImageUrl = "product-8.jpg",
            //         Name = "Primitive Sports Premium Shoes",
            //         CategoryId = 3,
            //         Count = 35,
            //         Price = 75.00,
            //         DisCountPrice = 70.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     },
            //      new Product
            //      {
            //          Id = 9,
            //          ImageUrl = "product-9.jpg",
            //          Name = "Primitive Fabric Premium Shoes",
            //          CategoryId = 4,
            //          Count = 35,
            //          Price = 40.00,
            //          DisCountPrice = 30.00,
            //          Availability = true,
            //          Title = "Lorem ipsum dolor sit amet",
            //          Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //      },
            //     new Product
            //     {
            //         Id = 10,
            //         ImageUrl = "product-10.jpg",
            //         Name = "Primitive Leather Premium Shoes",
            //         CategoryId = 5,
            //         Count = 35,
            //         Price = 90.00,
            //         DisCountPrice = 80.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     },
            //     new Product
            //     {
            //         Id = 11,
            //         ImageUrl = "product-11.jpg",
            //         Name = "Primitive Womans Premium Shoes",
            //         CategoryId = 2,
            //         Count = 35,
            //         Price = 50.00,
            //         DisCountPrice = 40.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     },
            //     new Product
            //     {
            //         Id = 12,
            //         ImageUrl = "product-12.jpg",
            //         Name = "Primitive Sports Premium Shoes",
            //         CategoryId = 3,
            //         Count = 35,
            //         Price = 75.00,
            //         DisCountPrice = 70.00,
            //         Availability = true,
            //         Title = "Lorem ipsum dolor sit amet",
            //         Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

            //     }
            // );

        }
    }
}
