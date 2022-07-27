using BackEndProject.DAL;
using BackEndProject.Extentions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    [Authorize(Roles = "SuperAdmin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {            
            
            return View(_context.Products.Include(p=>p.ProductImage).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Products = new SelectList(_context.Products
                .Include(p=>p.ProductImage).Include(p=>p.ProductTags)
                .ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.Where(p => p.ParentId != null).ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.ProductImage = new SelectList(_context.ProductImages.ToList(), "Id", "ImageUrl");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            Product dbProduct = await _context.Products.FindAsync(product.Id);
            Product dbProductName = new Product();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (product.Name == null)
            {
                ModelState.AddModelError("Name", "Category Name Cannot be Empty!");
                return View();
            }
            else
            {
                dbProductName = await _context.Products.FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == product.Name.Trim().ToLower());
            }
            if (dbProductName != null)
            {
                if (dbProductName.Name.Trim().ToLower() == product.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "This Name Is already Exist!");
                    return View();
                }
            }

            //if (product.Image == null)
            //{
            //    ModelState.AddModelError("Image", "Select Image");
            //    return View();
            //}

            //if (!product.Image.IsImage())
            //{
            //    ModelState.AddModelError("Image", "Only Image Files");
            //    return View();
            //}

            //if (product.Image.ValidSize(1000))
            //{
            //    ModelState.AddModelError("Image", "Size is higher max 1mb");
            //    return View();
            //}

            Product newProduct = new Product()
            {
                Name = product.Name,
                //ImageUrl = category.Image.SaveImage(_env, "assets/images"),
                CreateAt = System.DateTime.Now,
            };
            await _context.Products.AddAsync(newProduct);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
