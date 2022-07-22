﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public bool IsMain { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}