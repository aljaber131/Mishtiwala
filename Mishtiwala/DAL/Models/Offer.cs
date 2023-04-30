using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = false;

        [Required]
        public double DiscountAmount { get; set; }

        public int SweetId { get; set; }

        [ForeignKey(nameof(SweetId))]
        public Sweet Sweet { get; set;}
    }
}
