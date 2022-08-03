using BackEndProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BackEndProject.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;
        private readonly UserManager<AppUser> _userManager;
        public ChatController(ILogger<ChatController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            ViewBag.Users = _userManager.Users.ToList();
            return View();
        }
        public IActionResult Group()
        {
            ViewBag.UserName = User.Identity.Name;

            return View();
        }

    }
}
