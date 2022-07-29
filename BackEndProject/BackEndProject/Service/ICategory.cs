using BackEndProject.Models;
using System.Collections.Generic;

namespace BackEndProject.Service
{
    public interface ICategory
    {
        List<Category> category(Category category);
    }
}
