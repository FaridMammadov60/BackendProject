using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class RoleVM
    {
        public string UserName { get; set; }
        public List<IdentityRole> roles { get; set; }
        public IList<string> userRoles { get; set; }
        public string UserId { get; set; }
    }
}
