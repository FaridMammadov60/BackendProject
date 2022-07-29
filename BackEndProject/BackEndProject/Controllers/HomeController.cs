using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.Service;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategory _icategory;
        public HomeController(AppDbContext context, ICategory icategory)
        {
            _context = context;
            _icategory = icategory;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            //homeVM.Sliders = _context.Sliders.ToList();
            homeVM.SliderContents = _context.SliderContents.Include(p => p.Slider).ToList();
            homeVM.Banners = _context.Banners.ToList();
            homeVM.Categories = _context.Categories.Include(p => p.Children).Include(p => p.Products).ToList();
            homeVM.Products = _context.Products.Include(p => p.ProductImage).Include(p => p.Category).ToList();
            homeVM.ProductImages = _context.ProductImages.Include(p => p.Product).ToList();
            homeVM.Brands = _context.Brands.ToList();
            //ViewBag.CategoryD = _context.Categories.Include(p => p.Children).Include(p => p.Products).ToList();

            ViewBag.CategoryD = _icategory.category();
            return View(homeVM);
        }

        public IActionResult SearchProduct(string search)
        {
            List<Product> products = _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Where(p => p.Name.ToLower()
                .Contains(search.ToLower()))
                .Take(10)
                .ToList();
            return PartialView("SearchPartial", products);
        }

    }
}
