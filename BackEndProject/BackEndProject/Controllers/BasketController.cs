using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public BasketController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> AddItem(int? id)
        {
            //HttpContext.Session.SetString("name", "Farid");
            //Response.Cookies.Append("GROUP", "P322", new CookieOptions { MaxAge=TimeSpan.FromDays(14)});
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            List<BasketVM> products;

            if (Request.Cookies["basket"] == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            BasketVM existProduct = products.Find(x => x.Id == id);
            if (existProduct == null)
            {
                BasketVM basketVM = new BasketVM()
                {
                    Id = dbProduct.Id,
                    Price = dbProduct.Price,

                    ProductCount = 1

                };
                basketVM.ProductTotalPrice = basketVM.Price;
                products.Add(basketVM);
            }
            else
            {
               existProduct.ProductCount++;
               existProduct.ProductTotalPrice= existProduct.Price * existProduct.ProductCount;
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            return RedirectToAction("index", "home");

        }

        public IActionResult ShowItem()
        {
            //string name= HttpContext.Session.GetString("name");
            //string group=Request.Cookies["GROUP"];
            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == item.Id);
                    item.Price = dbProduct.Price;
                    item.CategoryId = dbProduct.CategoryId;
                    //item.ImageUrl = dbProduct.ImageUrl;
                    item.Name = dbProduct.Name;
                }
            }
            else
            {
                products = new List<BasketVM>();
            }
            return View(products);
        }

        [HttpPost]
        [ActionName("ShowItem")]
        public async Task<IActionResult> Sale()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                //Sale sale = new Sale();
                //sale.SaleDate = DateTime.Now;
                //sale.AppUserId = user.Id;

                //List<BasketVM> basketProducts = JsonConvert.
                //    DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                //List<SalesProduct> saleProducts = new List<SalesProduct>();
                //double total = 0;
                //foreach (var basketProduct in basketProducts)
                //{
                //    Product dbProduct = await _context.Products.FindAsync(basketProduct.Id);
                //    if (basketProduct.ProductCount > dbProduct.Count)
                //    {
                //        TempData["fail"] = "sale fail";
                //        return RedirectToAction("ShowItem");
                //    }
                //    SalesProduct saleProduct = new SalesProduct();
                //    saleProduct.ProductId = dbProduct.Id;
                //    saleProduct.Count = basketProduct.ProductCount;
                //    saleProduct.Price = dbProduct.Price;
                //    saleProduct.Id = sale.Id;
                //    saleProducts.Add(saleProduct);
                //    total += basketProduct.ProductCount * dbProduct.Count;
                //    dbProduct.Count = dbProduct.Count - saleProduct.Count;

                //}
                //sale.SalesProducts = saleProducts;
                //await _context.AddAsync(sale);
                //await _context.SaveChangesAsync();
                //TempData["success"] = "sale success";
                return RedirectToAction("ShowItem");

            }
            else
            {
                return View("login", "account");
            }
        }
        public IActionResult Minus(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM dbProduct = products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();
            if (dbProduct.ProductCount > 1)
            {
                dbProduct.ProductCount--;
            }
            else
            {
                products.Remove(dbProduct);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            return RedirectToAction("showitem", "basket");
        }
        public IActionResult Plus(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM dbProduct = products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();

            dbProduct.ProductCount++;

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            return RedirectToAction("showitem", "basket");
        }
        public IActionResult Remove(int? id)
        {
            if (id == null) return NotFound();


            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM dbProduct = products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();

            products.Remove(dbProduct);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

            return RedirectToAction("showitem", "basket");
        }
    }
}
