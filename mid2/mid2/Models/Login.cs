using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mid2.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Id is required")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "ID must be in format xx-xxxxx-x")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}