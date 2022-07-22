using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Nullable<DateTime> CreateAt { get; set; }
        public Nullable<DateTime> DeleteAt { get; set; }
        public Nullable<DateTime> UpdateAt { get; set; }

        public List<Product> Products { get; set; }
    }
}
