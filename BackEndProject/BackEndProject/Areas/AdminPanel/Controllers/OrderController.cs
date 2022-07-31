using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public OrderController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            List<AppUser> users = await _userManager.Users.Include(o => o.Orders).ThenInclude(i => i.OrderItems).ToListAsync();
            OrderVM orderVM = new OrderVM();
            List<Order> orders = _context.Orders.Include(u => u.AppUser).Include(o => o.OrderItems).OrderByDescending(t => t.SaledAt).ToList();
            orderVM.Orders = orders;
            orderVM.AppUsers = users;
            return View(orderVM);
        }
    }
}
