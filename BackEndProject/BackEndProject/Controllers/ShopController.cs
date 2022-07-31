using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.Service;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategory _icategory;
        private readonly UserManager<AppUser> _userManager;
        public ShopController(AppDbContext context, ICategory icategory, UserManager<AppUser> userManager)
        {
            _context = context;
            _icategory = icategory;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 8)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.User = user;
            }

            List<Product> products = _context.Products.Include(p => p.ProductImage)
                 .Skip((page - 1) * take).Take(take).ToList();
            PaginationVM<Product> paginationVM = new PaginationVM<Product>(products, PageCount(take), page);

            return View(await Task.FromResult(paginationVM));
        }
        private int PageCount(int take)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            List<Product> products = _context.Products.ToList();
            return (int)Math.Ceiling((decimal)products.Count() / take);
        }
        public IActionResult Detail(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            ViewBag.ProductImage = _context.ProductImages.Where(p => p.ProductId == id).ToList();
            Product product = _context.Products.Include(p => p.Category)
                .Include(p => p.ProductImage)
                .Include(b => b.Brand)
                .Include(t => t.ProductTags)
                .ThenInclude(t => t.Tag)
                .FirstOrDefault(b => b.Id == id);
            return View(product);
        }

    }
}
