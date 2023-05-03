using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;

namespace BLL.Services
{
    public class CategoryServices
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryServices() 
        {
            _categoryRepository = DataAccessFactory.CategoryData();
        }

        public void CreateCategory(CategoryDTO category)
        {
            _categoryRepository.Add(new Category
            {
                Name = category.Name,
            });
        }
    }
}
