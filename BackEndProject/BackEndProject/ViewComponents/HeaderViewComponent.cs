﻿using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.Service;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategory _icategory;
        public HeaderViewComponent(AppDbContext context, UserManager<AppUser> userManager, ICategory icategory)
        {
            _context = context;
            _userManager = userManager;
            _icategory = icategory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    ViewBag.User = user.UserName;
                }
            }
            else
            {
                return View();
            }

            ViewBag.BasketCount = 0;
            ViewBag.TotalPrice = 0;
            double totalPrice = 0;
            double total = 0;
            int totalCount = 0;
            string userName = "";
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            string basket = Request.Cookies[$"{userName}basket"];
            if (basket != null)
            {
                List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                //ViewBag.BasketCount =products.Count();
                foreach (var item in products)
                {
                    totalPrice += item.Price * item.ProductCount;
                    totalCount += item.ProductCount;
                    total += totalPrice;
                }
            }
            ViewBag.BasketCount = totalCount;
            ViewBag.TotalPrice = totalPrice;
            Bio bio = _context.Bios.FirstOrDefault();
            ViewBag.CategoryD = _icategory.category();
            return View(await Task.FromResult(bio));
        }
    }
}
