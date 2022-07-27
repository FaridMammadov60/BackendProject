using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Models
{
    public class AppUser:IdentityUser
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }        
       
        //public List<Order> Order { get; set; }
    }
}
