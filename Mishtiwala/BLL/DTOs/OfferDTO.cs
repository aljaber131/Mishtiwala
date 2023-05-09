using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OfferDTO
    {
        
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public double DiscountAmount { get; set; }
        public int SweetId { get; set; }
        
    
}
}
