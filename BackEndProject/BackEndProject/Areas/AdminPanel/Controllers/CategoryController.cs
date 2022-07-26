﻿using BackEndProject.DAL;
using BackEndProject.Extentions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    [Authorize(Roles = "SuperAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;

        public CategoryController(AppDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View(_context.Categories.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View(_context.Categories.FirstOrDefault(b => b.Id == id));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(b => b.Id == id);
            if (dbCategory == null) return NotFound();
            dbCategory.IsDeleted = true;
            dbCategory.DeleteAt = System.DateTime.Now;
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
            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(b => b.Id == id);
            if (dbCategory == null) return NotFound();
            Category dbCategoryName = await _context.Categories.Where(d => d.IsDeleted == false).FirstOrDefaultAsync(b => b.Name == dbCategory.Name);
            if (dbCategoryName != null)
            {
                dbCategoryName.IsDeleted = true;
            }
            dbCategory.IsDeleted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            ViewBag.CategoriesCreate = new SelectList(_context.Categories.Where(p => p.ParentId == null).ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            ViewBag.CategoriesCreate = new SelectList(_context.Categories.Where(p => p.ParentId == null).ToList(), "Id", "Name");

            Category dbCategory = await _context.Categories.FindAsync(category.Id);
            Category dbCategoryName = new Category();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "Category Name Cannot be Empty!");
                return View();
            }
            else
            {
                dbCategoryName = await _context.Categories.FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            }
            if (dbCategoryName != null)
            {
                if (dbCategoryName.Name.Trim().ToLower() == category.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "This Name Is already Exist!");
                    return View();
                }
            }

            if (category.Image == null)
            {
                ModelState.AddModelError("Image", "Select Image");
                return View();
            }

            if (!category.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Only Image Files");
                return View();
            }

            if (category.Image.ValidSize(1000))
            {
                ModelState.AddModelError("Image", "Size is higher max 1mb");
                return View();
            }

            Category newCategory = new Category()
            {
                Name = category.Name,
                ImageUrl = category.Image.SaveImage(_env, "assets/images"),
                CreateAt = System.DateTime.Now,
            };
            await _context.Categories.AddAsync(newCategory);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SubCreate()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            ViewBag.CategoriesCreate = new SelectList(_context.Categories.Where(p => p.ParentId == null).ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubCreate(Category category)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            Category dbCategory = await _context.Categories.FindAsync(category.Id);
            Category dbCategoryName = new Category();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "Category Name Cannot be Empty!");
                return View();
            }
            else
            {
                dbCategoryName = await _context.Categories.FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            }
            if (dbCategoryName != null)
            {
                if (dbCategoryName.Name.Trim().ToLower() == category.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "This Name Is already Exist!");
                    return View();
                }
            }

            if (category.Image == null)
            {
                ModelState.AddModelError("Image", "Select Image");
                return View();
            }

            if (!category.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Only Image Files");
                return View();
            }

            if (category.Image.ValidSize(1000))
            {
                ModelState.AddModelError("Image", "Size is higher max 1mb");
                return View();
            }

            Category newCategory = new Category()
            {
                Name = category.Name,
                ImageUrl = category.Image.SaveImage(_env, "assets/images"),
                CreateAt = System.DateTime.Now,
            };
            await _context.Categories.AddAsync(newCategory);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();

            return View(dbCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            Category dbCategory = await _context.Categories.FindAsync(category.Id);
            Category dbCategoryName = new Category();

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "Brand Name Cannot be Empty!");
                return View();
            }
            else
            {
                dbCategoryName = await _context.Categories.FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            }
            if (dbCategoryName != null)
            {
                if (dbCategoryName.Name.Trim().ToLower() != dbCategory.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "This Name Is already Exist!");
                    return View();
                }
            }
            if (dbCategory == null)
            {
                return View();
            }
            string path = "";

            if (category.Image == null)
            {
                dbCategory.ImageUrl = dbCategory.ImageUrl;
            }
            else
            {
                if (!category.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image Files");
                    return View();
                }

                if (category.Image.ValidSize(1000))
                {
                    ModelState.AddModelError("Photo", "Size is higher max 1mb");
                    return View();
                }
                string oldImg = dbCategory.ImageUrl;
                if (oldImg != null)
                {
                    path = Path.Combine(_env.WebRootPath, "assets/images", oldImg);
                }
                if (path != null)
                {
                    Helper.Helpers.DeleteImage(path);
                }
                else return NotFound();

                dbCategory.ImageUrl = category.Image.SaveImage(_env, "assets/images");
            }


            dbCategory.Name = category.Name;
            dbCategory.UpdateAt = System.DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
