using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        public Nullable<DateTime> CreateAt { get; set; }
        public Nullable<DateTime> DeleteAt { get; set; }
        public Nullable<DateTime> UpdateAt { get; set; }
        public List<Product> Products { get; set; }
        public bool IsDeleted { get; set; }
    }
}
