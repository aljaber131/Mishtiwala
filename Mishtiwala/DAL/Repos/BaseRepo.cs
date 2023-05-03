using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class BaseRepo
    {
        public ApplicationContext _dbContext;
        public BaseRepo()
        {
            _dbContext = new ApplicationContext();
        }
    }
}
