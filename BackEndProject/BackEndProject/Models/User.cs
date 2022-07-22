using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Order> Orders { get; set; }
        List<BasketItem> BasketItems { get; set; }
    }
}
