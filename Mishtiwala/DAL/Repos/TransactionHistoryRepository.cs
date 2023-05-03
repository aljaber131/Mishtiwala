using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class TransactionHistoryRepository : BaseRepo, IRepository<TransactionHistory>
    {

        public TransactionHistory GetById(int id)
        {
            return _dbContext.TransactionHistories.Find(id);
        }

        public IEnumerable<TransactionHistory> GetAll()
        {
            return _dbContext.TransactionHistories.ToList();
        }

        public void Add(TransactionHistory entity)
        {
            _dbContext.TransactionHistories.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TransactionHistory entity)
        {
            var existingEntity = _dbContext.TransactionHistories.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(TransactionHistory entity)
        {
            _dbContext.TransactionHistories.Remove(entity);
            _dbContext.SaveChanges();
        }
    }

}
