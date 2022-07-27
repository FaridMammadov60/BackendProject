using BackEndProject.DAL;
using BackEndProject.Extentions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

            return View(_context.Products.Include(p => p.ProductImage).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.Where(p => p.ParentId != null).ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Tag = new SelectList(_context.Tags.ToList(), "Id", "Name");

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

            if (product.Image == null)
            {
                ModelState.AddModelError("Image", "Select Image");
                return View();
            }

            if (!product.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Only Image Files");
                return View();
            }

            if (product.Image.ValidSize(1000))
            {
                ModelState.AddModelError("Image", "Size is higher max 1mb");
                return View();
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
                Image = product.Image
            };

            List<ProductImage> newProductImages = new List<ProductImage>();
            ProductImage newProductImage = new ProductImage()
            {
                ImageUrl = product.Image.SaveImage(_env, "assets/images/product"),
                ProductId = newProduct.Id
            };
            newProductImages.Add(newProductImage);
            newProduct.ProductImage = newProductImages;

            List<ProductTag> productTags = new List<ProductTag>();
            foreach (int item in product.TagId)
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
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
            if (dbProduct == null) return NotFound();
            dbProduct.IsDeleted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public IActionResult Detail(int? id)
        {
            ViewBag.ProductImage = _context.ProductImages.Where(p => p.ProductId == id).ToList();
            return View(_context.Products.FirstOrDefault(b => b.Id == id));
        }

        public async Task<IActionResult> Update(int? id)
        {
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
            Product dbProduct = await _context.Products.FindAsync(product.Id);
            Product dbProductName = new Product();
          
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (product.Name == null)
            {
                ModelState.AddModelError("Name", "Brand Name Cannot be Empty!");
                return View();
            }
            else
            {
                dbProductName = await _context.Products.FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == product.Name.Trim().ToLower());
            }
            if (dbProductName != null)
            {
                if (dbProductName.Name.Trim().ToLower() != dbProduct.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "This Name Is already Exist!");
                    return View();
                }
            }
            if (dbProduct == null)
            {
                return View();
            }
            
                             
            
            else
            {
                if (!product.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image Files");
                    return View();
                }

                if (product.Image.ValidSize(1000))
                {
                    ModelState.AddModelError("Photo", "Size is higher max 1mb");
                    return View();
                }
                //string oldImg = dbProduct.ImageUrl;
                //if (oldImg != null)
                //{
                //    path = Path.Combine(_env.WebRootPath, "assets/images/product", oldImg);
                //}
               
                else return NotFound();

                //dbProduct.ImageUrl = product.Image.SaveImage(_env, "assets/images/product");
            }

            dbProduct.Name = product.Name;
            dbProduct.IsFeatured = product.IsFeatured;
            dbProduct.BestSeller = product.BestSeller;
            dbProduct.NewArrivle = product.NewArrivle;
            dbProduct.StockCount = product.StockCount;
            dbProduct.Price = product.Price;
            dbProduct.DisCountPrice = product.DisCountPrice;
            dbProduct.Title = product.Title;
            dbProduct.Desc = product.Desc;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.BrandId = product.BrandId;
            dbProduct.InStock = product.InStock;
            dbProduct.Image = product.Image;
            dbProduct.UpdateAt = System.DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
