using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsFeatured { get; set; }
        public bool BestSeller { get; set; }
        public bool NewArrivle { get; set; }
        public bool InStock { get; set; }
        public int StockCount { get; set; }
        public double Price { get; set; }
        public double DisCountPrice { get; set; }
        public double TaxPrecent { get; set; }        
        public string Title { get; set; }
        public string Desc { get; set; }

        public Nullable<DateTime> CreateAt { get; set; }
        public Nullable<DateTime> DeleteAt { get; set; }
        public Nullable<DateTime> UpdateAt { get; set; }       

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public List<ProductTag> ProductTags { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }
}
