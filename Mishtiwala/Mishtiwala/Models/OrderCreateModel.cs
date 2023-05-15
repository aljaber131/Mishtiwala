using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mishtiwala.Models
{
    public class OrderCreateModel
    {
        [Required]
        public UserModel User { get; set; }

        [Required]
        public List<OrderItemModel> OrderItems { get; set; }
    }
}