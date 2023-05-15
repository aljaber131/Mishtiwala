using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class OrderItemRepository : BaseRepo, IRepository<OrderItem>
    {
    
        public OrderItem GetById(int id)
        {
            return _dbContext.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Sweet)
                .FirstOrDefault(oi => oi.Id == id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _dbContext.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Sweet)
                .ToList();
        }

        public void Add(OrderItem entity)
        {
            _dbContext.OrderItems.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(OrderItem entity)
        {
            var existingEntity = _dbContext.OrderItems.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(OrderItem entity)
        {
            _dbContext.OrderItems.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
