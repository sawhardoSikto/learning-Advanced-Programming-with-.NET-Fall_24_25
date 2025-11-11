using SecondLab.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondLab.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z .-]+$",
              ErrorMessage = "Name can contain only alphabets, space, dot, and dash.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^\S+$",
            ErrorMessage = "Username cannot contain spaces.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "ID is required")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$",
            ErrorMessage = "ID must be in format xx-xxxxx-x (digits only, last digit 1-3).")]
        
        public string Id { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [ValidDOB]
        
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [ValidEmail]
        
        
        public string Email { get; set; }
    }
}
