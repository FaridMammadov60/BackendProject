using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
