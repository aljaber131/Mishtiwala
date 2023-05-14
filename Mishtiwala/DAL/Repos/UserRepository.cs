using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepository : BaseRepo,IRepository<User>, IAuth
    {

        public User GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            var existingEntity = _dbContext.Users.Find(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public User Login(string username, string password)
        {
            return _dbContext.Users.Find(username,password);
        }
    }
}
