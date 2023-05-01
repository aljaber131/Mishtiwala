using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mishtiwala.Models
{
    public class UserCreateModel
    {
        [Required]
        [MinLength(2,ErrorMessage ="At least 2 character needed")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "At least 2 character needed")]
        public string LastName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "At least 2 character needed")]
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "At least 8 character needed")]
        public string Password { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "At least 2 character needed")]
        public string Address { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "At least 2 character needed")]
        public string Phone { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "At least 2 character needed")]
        public string Role { get; set; }
    }
}