using BackEndProject.DAL;
using BackEndProject.Extentions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
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
        private readonly UserManager<AppUser> _userManager;
        private IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public ProductController(AppDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager, IConfiguration config)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
            _config = config;
        }
        public IActionResult Index(int page = 1, int take = 5)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            List<Product> products = _context.Products.Include(p => p.Category).Include(p => p.ProductImage)
                .Skip((page - 1) * take).Take(take).ToList();

            PaginationVM<Product> paginationVM = new PaginationVM<Product>(products, PageCount(take), page);

            return View(paginationVM);
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

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            ViewBag.Categories = new SelectList(_context.Categories.Where(p => p.ParentId != null).ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Tag = new SelectList(_context.Tags.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            ViewBag.Categories = new SelectList(_context.Categories.Where(p => p.ParentId != null).ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Tag = new SelectList(_context.Tags.ToList(), "Id", "Name");

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
            bool existProductName = _context.Products.Where(c => c.IsDeleted != true).Any(c => c.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (existProductName)
            {
                ModelState.AddModelError("Name", "The name of product is exist");
                return View();
            }


            List<ProductImage> images = new List<ProductImage>();
            if (product.Image == null) return BadRequest();
            foreach (var item in product.Image)
            {
                if (item == null)
                {
                    ModelState.AddModelError("Photo", "Don't be Empty");
                    return View();
                }
                if (!item.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image Files");
                    return View();
                }

                if (item.ValidSize(2000))
                {
                    ModelState.AddModelError("Photo", "Size oversize");
                    return View();
                }

                ProductImage image = new ProductImage();
                image.ImageUrl = item.SaveImage(_env, "assets/images/product");

                if (product.Image.Count == 1)
                {
                    image.IsMain = true;
                }
                else
                {
                    for (int i = 0; i < images.Count; i++)
                    {
                        images[0].IsMain = true;
                    }
                }
                images.Add(image);
            }


            Product newProduct = new Product()
            {
                Name = product.Name,
                IsFeatured = product.IsFeatured,
                BestSeller = product.BestSeller,
                NewArrivle = product.NewArrivle,
                StockCount = product.StockCount,
                Price = product.Price,
                DisCountPrice = product.DisCountPrice,
                Title = product.Title,
                Desc = product.Desc,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                CreateAt = System.DateTime.Now,
                InStock = true,
                ProductImage = images
            };

            List<ProductTag> productTags = new List<ProductTag>();
            foreach (int item in product.TagPId)
            {
                ProductTag productTag = new ProductTag();
                productTag.TagId = item;
                productTag.ProductId = newProduct.Id;
                productTags.Add(productTag);
            }
            newProduct.ProductTags = productTags;

            await _context.Products.AddAsync(newProduct);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
            if (dbProduct == null) return NotFound();
            dbProduct.IsDeleted = true;
            dbProduct.DeleteAt = System.DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Restore(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
            if (dbProduct == null) return NotFound();
            Product dbproductName = await _context.Products.Where(d => d.IsDeleted == false).FirstOrDefaultAsync(b => b.Name == dbProduct.Name);
            if (dbproductName != null)
            {
                dbproductName.IsDeleted = true;
            }

            dbProduct.IsDeleted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public IActionResult Detail(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            ViewBag.ProductImage = _context.ProductImages.Where(p => p.ProductId == id).ToList();
            return View(_context.Products.FirstOrDefault(b => b.Id == id));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories.Where(p => p.ParentId != null).ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Tag = new SelectList(_context.Tags.ToList(), "Id", "Name");


            return View(dbProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product dbProduct = await _context.Products
                .Include(p => p.ProductImage)
                .Include(p => p.ProductTags)
                .ThenInclude(t => t.Tag)
                .Include(b => b.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == product.Id);
            if (dbProduct == null)
            {
                return View();
            }
            List<ProductImage> images = new List<ProductImage>();
            Product dbProductName = _context.Products.FirstOrDefault(c => c.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            string path = "";
            if (product.Image == null)
            {
                foreach (var item in dbProduct.ProductImage)
                {
                    item.ImageUrl = item.ImageUrl;
                }
            }
            else
            {
                foreach (var item in product.Image)
                {
                    if (item == null)
                    {
                        ModelState.AddModelError("Photo", "Don't be Empty");
                        return View();
                    }
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Only Image Files");
                        return View();
                    }

                    if (item.ValidSize(2000))
                    {
                        ModelState.AddModelError("Photo", "Size oversize");
                        return View();
                    }
                    ProductImage image = new ProductImage();
                    image.ImageUrl = item.SaveImage(_env, "assets/images/product");

                    if (product.Image.Count == 1)
                    {
                        image.IsMain = true;
                    }
                    else
                    {
                        for (int i = 0; i < images.Count; i++)
                        {
                            images[0].IsMain = true;
                        }
                    }
                    images.Add(image);
                }

                foreach (var item in product.Image)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Only Image Files");
                        return View();
                    }

                    if (item.ValidSize(1000))
                    {
                        ModelState.AddModelError("Photo", "Size is higher max 1mb");
                        return View();
                    }
                }
            }

            foreach (var item in dbProduct.ProductImage)
            {
                if (item.ImageUrl != null)
                {
                    path = Path.Combine(_env.WebRootPath, "assets/images/product", item.ImageUrl);
                }
            }
            if (path != null)
            {
                Helper.Helpers.DeleteImage(path);
            }
            else return NotFound();

            if (dbProductName != null)
            {
                if (dbProduct.Name != dbProduct.Name)
                {
                    ModelState.AddModelError("Name", "This Name already was taken");
                    return View();
                }
            }
            if (product.TagPId == null)
            {
                foreach (var item1 in dbProduct.ProductTags)
                {
                    item1.TagId = item1.TagId;
                }
            }
            else
            {
                List<ProductTag> productTags = new List<ProductTag>();
                foreach (int item in product.TagPId)
                {
                    ProductTag productTag = new ProductTag();
                    productTag.TagId = item;
                    productTag.ProductId = dbProduct.Id;
                    productTags.Add(productTag);
                }
                dbProduct.ProductTags = productTags;
            }


            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.ProductImage = images;
            dbProduct.StockCount = product.StockCount;
            dbProduct.IsDeleted = false;
            dbProduct.BestSeller = true;
            dbProduct.IsFeatured = false;

            dbProduct.Desc = product.Desc;
            // dbProduct.UptadeAt = System.DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
