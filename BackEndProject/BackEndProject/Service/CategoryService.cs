using BackEndProject.DAL;
using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.Service
{
    public class CategoryService : ICategory
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> category(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
