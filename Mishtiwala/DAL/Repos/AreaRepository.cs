using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class AreaRepository : IRepository<Area>
    {
        private readonly ApplicationContext _dbContext;

        public AreaRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Area GetById(int id)
        {
            return _dbContext.Areas.Find(id);
        }

        public IEnumerable<Area> GetAll()
        {
            return _dbContext.Areas.ToList();
        }

        public void Add(Area entity)
        {
            _dbContext.Areas.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Area entity)
        {
            var existingEntity = _dbContext.Areas.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Area entity)
        {
            _dbContext.Areas.Remove(entity);
            _dbContext.SaveChanges();
        }
    }

}
