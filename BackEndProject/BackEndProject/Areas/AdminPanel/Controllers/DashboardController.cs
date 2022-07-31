using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            //var curUser = await _userManager.GetUserAsync(HttpContext.User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View();
        }
    }
}
