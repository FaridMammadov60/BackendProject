using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; }
    }
}
