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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }



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
                  Offer = "Save $120 when you buy",
                  Title = "2020 Virtual Reality",
                  Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"

              },
              new SliderContent
              {
                  Id = 2,
                  Name = "Sony Bravia.",
                  Offer = "Save $120 when you buy",
                  Title = "4K HDR Smart TV 43",
                  Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"

              }
          );
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Mens"
               },
               new Category
               {
                   Id = 2,
                   Name = "Womens"
               },
                new Category
                {
                    Id = 3,
                    Name = "Sports"
                },
               new Category
               {
                   Id = 4,
                   Name = "Fabric"
               },
                new Category
                {
                    Id = 5,
                    Name = "Leather"
                }
           );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ImageUrl = "product-1.jpg",
                    Name = "Primitive Mens Premium Shoes",
                    CategoryId = 1,
                    Count = 35,
                    Price = 80.00,
                    DisCountPrice = 70.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 2,
                    ImageUrl = "product-2.jpg",
                    Name = "Quickin Womans Premium Shoes",
                    CategoryId = 2,
                    Count = 35,
                    Price = 90.00,
                    DisCountPrice = 80.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 3,
                    ImageUrl = "product-3.jpg",
                    Name = "Rexpo Sports Premium Shoes",
                    CategoryId = 3,
                    Count = 35,
                    Price = 50.00,
                    DisCountPrice = 40.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 4,
                    ImageUrl = "product-4.jpg",
                    Name = "Primitive Fabric Premium Shoes",
                    CategoryId = 4,
                    Count = 35,
                    Price = 75.00,
                    DisCountPrice = 70.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                 new Product
                 {
                     Id = 5,
                     ImageUrl = "product-5.jpg",
                     Name = "Primitive Leather slipper",
                     CategoryId = 5,
                     Count = 35,
                     Price = 40.00,
                     DisCountPrice = 30.00,
                     Availability = true,
                     Title = "Lorem ipsum dolor sit amet",
                     Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                 },
                new Product
                {
                    Id = 6,
                    ImageUrl = "product-6.jpg",
                    Name = "Primitive Mens Premium Shoes",
                    CategoryId = 1,
                    Count = 35,
                    Price = 90.00,
                    DisCountPrice = 80.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 7,
                    ImageUrl = "product-7.jpg",
                    Name = "Primitive Womans Premium Shoes",
                    CategoryId = 2,
                    Count = 35,
                    Price = 50.00,
                    DisCountPrice = 40.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 8,
                    ImageUrl = "product-8.jpg",
                    Name = "Primitive Sports Premium Shoes",
                    CategoryId = 3,
                    Count = 35,
                    Price = 75.00,
                    DisCountPrice = 70.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                 new Product
                 {
                     Id = 9,
                     ImageUrl = "product-9.jpg",
                     Name = "Primitive Fabric Premium Shoes",
                     CategoryId = 4,
                     Count = 35,
                     Price = 40.00,
                     DisCountPrice = 30.00,
                     Availability = true,
                     Title = "Lorem ipsum dolor sit amet",
                     Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                 },
                new Product
                {
                    Id = 10,
                    ImageUrl = "product-10.jpg",
                    Name = "Primitive Leather Premium Shoes",
                    CategoryId = 5,
                    Count = 35,
                    Price = 90.00,
                    DisCountPrice = 80.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 11,
                    ImageUrl = "product-11.jpg",
                    Name = "Primitive Womans Premium Shoes",
                    CategoryId = 2,
                    Count = 35,
                    Price = 50.00,
                    DisCountPrice = 40.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                },
                new Product
                {
                    Id = 12,
                    ImageUrl = "product-12.jpg",
                    Name = "Primitive Sports Premium Shoes",
                    CategoryId = 3,
                    Count = 35,
                    Price = 75.00,
                    DisCountPrice = 70.00,
                    Availability = true,
                    Title = "Lorem ipsum dolor sit amet",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid",

                }
            );

        }
    }
}
