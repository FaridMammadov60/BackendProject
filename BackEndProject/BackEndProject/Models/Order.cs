using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> CreateAt { get; set; }
        public Nullable<DateTime> DeleteAt { get; set; }
        public Nullable<DateTime> UpdateAt { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }

    public enum OrderStatus
    {
        Pending,
        Shipped
    }

}
