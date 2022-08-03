using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("AdminPanel")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View(_rolemanager.Roles.ToList());
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View(_rolemanager.Roles.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(string role)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            await _rolemanager.CreateAsync(new IdentityRole { Name = role });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            var result = await _rolemanager.FindByIdAsync(id);
            await _rolemanager.DeleteAsync(result);
            return RedirectToAction("Index");
        }
    }
}
