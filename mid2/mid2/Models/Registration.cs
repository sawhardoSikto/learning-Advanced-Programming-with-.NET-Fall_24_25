using mid2.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mid2.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Id is required")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$",ErrorMessage ="ID must be in format xx-xxxxx-x")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z .-]+$", ErrorMessage = "Id can only contain letters, spaces, periods, and hyphens.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        
        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        [ValidEmail]
        public string Email { get; set; }
        [Required(ErrorMessage = "please select the gender")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "Profession is required")]
        public string Profession { get; set; }
        [Required(ErrorMessage = "At least one hobby must be selected")]
        public string[] Hobbies { get; set; }

    }
}