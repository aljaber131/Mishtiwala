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

        public CategoryDTO GetCategoryById(int id)
        {
            var categoryEntity=_categoryRepository.GetById(id);
            if (categoryEntity == null)
            {
                return null;
            }
            CategoryDTO category = new CategoryDTO
            {
                Name = categoryEntity.Name,
                Id= categoryEntity.Id
            };
            return category;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            var list = _categoryRepository.GetAll();
            var categories = new List<CategoryDTO>();
            foreach (var category in list)
            {
                categories.Add(new CategoryDTO
                {
                    Name = category.Name,
                    Id = category.Id
                });
            }
            return categories;
        }

        public void UpdateCategory(CategoryDTO category,int id)
        {
            var entity = _categoryRepository.GetById(id);
            if (entity == null)
            {
                return;
            }
            entity.Name = category.Name;
            entity.Id = category.Id;
            _categoryRepository.Update(entity);
        }

        public void DeleteCategory(int id)
        {
            var entity = _categoryRepository.GetById(id);
            _categoryRepository.Delete(entity);
        }
    }
}
