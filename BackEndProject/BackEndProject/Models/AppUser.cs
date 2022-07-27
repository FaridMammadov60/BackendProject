using Microsoft.AspNetCore.Identity;

namespace BackEndProject.Models
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public List<Order> Order { get; set; }
    }
}
