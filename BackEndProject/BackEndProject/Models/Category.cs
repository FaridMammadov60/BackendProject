using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(1)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
