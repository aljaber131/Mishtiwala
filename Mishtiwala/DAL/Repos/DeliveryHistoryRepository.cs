using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class DeliveryHistoryRepository : IRepository<DeliveryHistory>
    {
        private readonly ApplicationContext _dbContext;

        public DeliveryHistoryRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DeliveryHistory GetById(int id)
        {
            return _dbContext.DeliveryHistories.Find(id);
        }

        public IEnumerable<DeliveryHistory> GetAll()
        {
            return _dbContext.DeliveryHistories.ToList();
        }

        public void Add(DeliveryHistory entity)
        {
            _dbContext.DeliveryHistories.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(DeliveryHistory entity)
        {
            var existingEntity = _dbContext.DeliveryHistories.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(DeliveryHistory entity)
        {
            _dbContext.DeliveryHistories.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
