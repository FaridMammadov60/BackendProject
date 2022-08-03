using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackEndProject.Service
{
    public class CategoryService : ICategory
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> category()
        {
            List<Category> categories = _context.Categories.Include(p => p.Children)
                .Include(p => p.Products).Where(p=>p.IsDeleted!=true).ToList();
            return categories;
        }
    }
}
