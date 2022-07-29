using BackEndProject.DAL;
using BackEndProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategory _icategory;
        public ShopController(AppDbContext context, ICategory icategory)
        {
            _context = context;
            _icategory = icategory;
        }
        public IActionResult Index()
        {

            ViewBag.CategoryD = _icategory.category();
            return View();
        }
    }
}
