using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class UserVM
    {
        public List<AppUser> Users { get; set; }
        public IList<string> userRoles  {  get; set; }
    }
}
