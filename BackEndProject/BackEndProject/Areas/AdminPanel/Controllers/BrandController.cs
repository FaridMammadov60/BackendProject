﻿using BackEndProject.DAL;
using BackEndProject.Extentions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    [Authorize(Roles = "SuperAdmin")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;

        public BrandController(AppDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager)
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
            return View(_context.Brands.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View(_context.Brands.FirstOrDefault(b => b.Id == id));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            if (id == null) return NotFound();
            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (dbBrand == null) return NotFound();
            dbBrand.IsDeleted = true;
            dbBrand.DeleteAt = System.DateTime.Now;
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
            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (dbBrand == null) return NotFound();
            Brand dbbrandName = await _context.Brands.Where(d => d.IsDeleted == false).FirstOrDefaultAsync(b => b.Name == dbBrand.Name);
            if (dbbrandName != null)
            {
                dbbrandName.IsDeleted = true;
            }
            dbBrand.IsDeleted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            Brand dbBrand = await _context.Brands.FindAsync(brand.Id);
            Brand dbBrandName = new Brand();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (brand.Name == null)
            {
                ModelState.AddModelError("Name", "Brand Name Cannot be Empty!");
                return View();
            }
            else
            {
                dbBrandName = await _context.Brands.FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == brand.Name.Trim().ToLower());
            }
            if (dbBrandName != null)
            {
                if (dbBrandName.Name.Trim().ToLower() == brand.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "This Name Is already Exist!");
                    return View();
                }
            }

            if (brand.Image == null)
            {
                ModelState.AddModelError("Image", "Select Image");
                return View();
            }

            if (!brand.Image.IsImage())
            {
                ModelState.AddModelError("Image", "Only Image Files");
                return View();
            }

            if (brand.Image.ValidSize(1000))
            {
                ModelState.AddModelError("Image", "Size is higher max 1mb");
                return View();
            }

            Brand newBrand = new Brand()
            {
                Name = brand.Name,
                ImageUrl = brand.Image.SaveImage(_env, "assets/images/brand"),
                CreateAt = System.DateTime.Now,
            };
            await _context.Brands.AddAsync(newBrand);

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
            Brand dbBrand = await _context.Brands.FindAsync(id);
            if (dbBrand == null) return NotFound();

            return View(dbBrand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Brand brand)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            Brand dbBrand = await _context.Brands.FindAsync(brand.Id);
            Brand dbBrandName = new Brand();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (brand.Name == null)
            {
                ModelState.AddModelError("Name", "Brand Name Cannot be Empty!");
                return View();
            }
            else
            {
                dbBrandName = await _context.Brands.FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == brand.Name.Trim().ToLower());
            }
            if (dbBrandName != null)
            {
                if (dbBrandName.Name.Trim().ToLower() != dbBrand.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "This Name Is already Exist!");
                    return View();
                }
            }
            if (dbBrand == null)
            {
                return View();
            }
            string path = "";

            if (brand.Image == null)
            {
                dbBrand.ImageUrl = dbBrand.ImageUrl;
            }
            else
            {
                if (!brand.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image Files");
                    return View();
                }

                if (brand.Image.ValidSize(1000))
                {
                    ModelState.AddModelError("Photo", "Size is higher max 1mb");
                    return View();
                }
                string oldImg = dbBrand.ImageUrl;
                if (oldImg != null)
                {
                    path = Path.Combine(_env.WebRootPath, "assets/images/brand", oldImg);
                }
                if (path != null)
                {
                    Helper.Helpers.DeleteImage(path);
                }
                else return NotFound();

                dbBrand.ImageUrl = brand.Image.SaveImage(_env, "assets/images/brand");
            }


            dbBrand.Name = brand.Name;
            dbBrand.UpdateAt = System.DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
