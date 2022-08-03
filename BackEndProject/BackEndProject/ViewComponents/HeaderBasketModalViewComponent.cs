using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.Service;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BackEndProject.ViewComponents
{
    public class HeaderBasketModalViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        

        public HeaderBasketModalViewComponent(AppDbContext context)
        {
            _context = context;         
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string username = "";

            username = User.Identity.Name;

            //string name = HttpContext.Session.GetString("name");
            string basket = Request.Cookies[$"{username}basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProducts = _context.Products.Include(pi => pi.ProductImage).FirstOrDefault(x => x.Id == item.Id);
                    item.Name = dbProducts.Name;

                    item.Price = dbProducts.Price;

                    foreach (var image in dbProducts.ProductImage)
                    {
                        if (image.IsMain)
                        {
                            item.ImageUrl = image.ImageUrl;
                        }
                    }
                }
            }
            else
            {
                products = new List<BasketVM>();
            }           
            return View(await Task.FromResult(products));
        }
    }
}
