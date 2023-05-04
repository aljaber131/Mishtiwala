using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class SweetRepository : BaseRepo, IRepository<Sweet>
    {

        public Sweet GetById(int id)
        {
            return _dbContext.Sweets.Find(id);
        }

        public IEnumerable<Sweet> GetAll()
        {
            return _dbContext.Sweets.ToList();
        }

        public void Add(Sweet entity)
        {
            _dbContext.Sweets.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Sweet entity)
        {
            var existingEntity = _dbContext.Sweets.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Sweet entity)
        {
            _dbContext.Sweets.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
