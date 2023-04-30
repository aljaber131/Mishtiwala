using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class OfferRepository : IRepository<Offer>
    {
        private readonly ApplicationDbContext _dbContext;

        public OfferRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Offer GetById(int id)
        {
            return _dbContext.Offers.Find(id);
        }

        public IEnumerable<Offer> GetAll()
        {
            return _dbContext.Offers.ToList();
        }

        public void Add(Offer entity)
        {
            _dbContext.Offers.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Offer entity)
        {
            var existingEntity = _dbContext.Offers.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Offer entity)
        {
            _dbContext.Offers.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
