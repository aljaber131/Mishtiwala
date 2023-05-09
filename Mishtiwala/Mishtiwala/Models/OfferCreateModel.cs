using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mishtiwala.Models
{
    public class OfferCreateModel
    {
        [Required]
        public bool IsActive { get; set; } = false;

        [Required]
        public double DiscountAmount { get; set; }

        [Required]
        public int SweetId { get; set; }
    }
}