using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepository : BaseRepo, IRepository<Category>
    {
        public Category GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public void Add(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            var existingEntity = _dbContext.Categories.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            _dbContext.Categories.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
