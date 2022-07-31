using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class UserInfoVM
    {
        public int Id { get; set; }
        public AppUser appUser { get; set; }
        public List<Order> orders { get; set; }
    }
}
