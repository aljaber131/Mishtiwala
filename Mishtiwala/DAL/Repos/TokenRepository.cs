using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class TokenRepository : BaseRepo, IRepository<Token>, IToken
    {
        public void Add(Token entity)
        {
            _dbContext.Tokens.Add(entity);
        }

        public void Delete(Token entity)
        {
            _dbContext.Tokens.Remove(entity);
        }

        public IEnumerable<Token> GetAll()
        {
            throw new NotImplementedException();
        }

        public Token GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Token IsValidToken(string token)
        {
            return _dbContext.Tokens.FirstOrDefault(x => x.Equals(token));
        }

        public void Update(Token entity)
        {
            throw new NotImplementedException();
        }
    }
}
