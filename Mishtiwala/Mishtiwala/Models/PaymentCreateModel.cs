using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mishtiwala.Models
{
    public class PaymentCreateModel
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public int SweetId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}