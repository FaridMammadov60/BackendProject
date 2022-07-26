using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public Nullable<DateTime> CreateAt { get; set; }
        public Nullable<DateTime> DeleteAt { get; set; }
        public Nullable<DateTime> UpdateAt { get; set; }

        public List<Product> Products { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public bool IsDeleted { get; set; }
    }
}
