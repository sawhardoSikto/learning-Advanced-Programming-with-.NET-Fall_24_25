using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondLab.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^\S+$",
          ErrorMessage = "Username cannot contain spaces.")]
        public string Username  { get; set; }
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

    }
}