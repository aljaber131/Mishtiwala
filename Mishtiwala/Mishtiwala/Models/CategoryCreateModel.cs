using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mishtiwala.Models
{
    public class CategoryCreateModel
    {
        [Required]
        [MinLength(1,ErrorMessage ="At least 1 Charecter")]
        public string Name { get; set; }
    }
}