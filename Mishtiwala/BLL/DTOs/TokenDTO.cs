using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public string TokenKey { get; set; }

        public string Role { get; set; }

        public int UserId { get; set; }
        
    }
}
