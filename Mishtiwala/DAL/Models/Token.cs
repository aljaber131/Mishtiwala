using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Token
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TokenKey { get; set; }

        [Required]
        public string Role { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set;}
        public User User { get; set;}
    }
}
