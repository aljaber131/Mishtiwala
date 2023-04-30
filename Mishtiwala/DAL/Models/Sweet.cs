using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Sweet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int AreaId { get; set; }

        [ForeignKey(nameof(AreaId))]
        public Area Area { get; set; }
    }
}
