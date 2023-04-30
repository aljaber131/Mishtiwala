using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PaymentRepository : IRepository<Payment>
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Payment GetById(int id)
        {
            return _dbContext.Payments.Find(id);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _dbContext.Payments.ToList();
        }

        public void Add(Payment entity)
        {
            _dbContext.Payments.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Payment entity)
        {
            var existingEntity = _dbContext.Payments.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Payment entity)
        {
            _dbContext.Payments.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
