using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public SweetDTO Sweet { get; set; }
        public int SweetId { get; set; }
        public int Quantity { get; set; }
    }
}
