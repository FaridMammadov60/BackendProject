﻿using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.Service;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEndProject.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategory _icategory;


        public BasketController(AppDbContext context, UserManager<AppUser> userManager, ICategory icategory)
        {
            _context = context;
            _userManager = userManager;
            _icategory = icategory;

        }
        string userName = "";
        public IActionResult Index()
        {
            return View();
        }
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(int? id)
        {
            double price = 0;
            double count = 0;
            ViewBag.IsLogin = User.Identity.IsAuthenticated;

            userName = User.Identity.Name;
            if (id == null) return NotFound();

            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            List<BasketVM> products;

            if (Request.Cookies[$"{userName}basket"] == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>((Request.Cookies[$"{userName}basket"]));
            }
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (existProduct == null)
            {
                BasketVM basketVM = new BasketVM
                {
                    Id = dbProduct.Id,
                    ProductCount = 1,
                    Price = dbProduct.Price
                };
                products.Add(basketVM);
            }
            else
            {
                existProduct.ProductCount++;
            }

            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });



            foreach (var product in products)
            {
                price += product.Price * product.ProductCount;
                count += product.ProductCount;
            }
            var obj = new
            {
                Price = price,
                Count = count,
            };

            //return Ok(obj);
            return RedirectToAction("index", "home");

        }

        public IActionResult ShowItem()
        {
            ViewBag.brand = _context.Brands.Where(b => b.IsDeleted != true).ToList();
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            string basket = Request.Cookies[$"{userName}basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products
                    .Include(c => c.Category)
                    .Include(i => i.ProductImage)
                    .FirstOrDefault(p => p.Id == item.Id);
                    item.Price = dbProduct.Price;
                    item.Name = dbProduct.Name;
                    item.Category = dbProduct.Category.Name;
                    item.Desc = dbProduct.Desc;
                    foreach (var prod in dbProduct.ProductImage)
                    {
                        item.ImageUrl = prod.ImageUrl;
                    }
                }
            }
            else
            {
                products = new List<BasketVM>();
            }
            ViewBag.CategoryD = _icategory.category();
            return View(products);
        }
        public IActionResult min(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            List<BasketVM> products;
            string basket = Request.Cookies[$"{userName}basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (existProduct.ProductCount > 1)
            {
                existProduct.ProductCount--;
            }
            else
            {
                products.Remove(existProduct);
            }
            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });

            return RedirectToAction("showitem", "basket");
        }
        public IActionResult plus(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            List<BasketVM> products;
            string basket = Request.Cookies[$"{userName}basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (product.StockCount <= existProduct.ProductCount)
            {
                TempData["failCount"] = $"{product.Name}-dan bazada cemisi {product.StockCount} eded var";
            }
            else
            {
                existProduct.ProductCount++;
            }
            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            //return RedirectToAction("showitem", $"{userName}basket");
            return RedirectToAction("showItem", "basket");
        }
        public IActionResult removeItem(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            List<BasketVM> products;
            string basket = Request.Cookies[$"{userName}basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            BasketVM existProduct = products.Find(p => p.Id == id);
            products.Remove(existProduct);
            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            return RedirectToAction("showitem", "basket");
        }


        [HttpPost]
        public async Task<IActionResult> Order()
        {
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order();
                order.SaledAt = DateTime.Now;
                order.AppUserId = user.Id;

                List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies[$"{userName}basket"]);
                List<OrderItem> orderItems = new List<OrderItem>();
                double total = 0;
                foreach (var basketProduct in basketProducts)
                {
                    Product dbProduct = await _context.Products.FindAsync(basketProduct.Id);
                    if (basketProduct.ProductCount > dbProduct.StockCount)
                    {
                        TempData["fail"] = "Satış uğursuzdur..";
                        return RedirectToAction("ShowItem");
                    }
                    OrderItem orderItem = new OrderItem();
                    orderItem.ProductId = dbProduct.Id;
                    orderItem.Count = basketProduct.ProductCount;
                    orderItem.OrderId = order.Id;
                    orderItem.TotalPrice = dbProduct.Price;
                    orderItems.Add(orderItem);
                    total += basketProduct.ProductCount * dbProduct.Price;

                    dbProduct.StockCount = dbProduct.StockCount - basketProduct.ProductCount;
                }
                order.OrderItems = orderItems;
                order.TotalPrice = total;

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
                TempData["success"] = "Satış uğurla başa çatdı..";
                return RedirectToAction("ShowItem");
            }
            else
            {
                return RedirectToAction("login", "account");
            }

        }
    }
}
