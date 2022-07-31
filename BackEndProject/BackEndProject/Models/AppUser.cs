using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Order> Orders { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public Nullable<DateTime> UserCreateTime { get; set; }
        public Nullable<DateTime> UserDeletedTime { get; set; }
        public Nullable<DateTime> UserUpdateTime { get; set; }
        public DateTime ConfirmMailTime { get; set; }
    }
}
